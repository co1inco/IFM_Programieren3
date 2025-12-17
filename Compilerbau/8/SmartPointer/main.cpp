#include <iostream>
#include <memory>
#include <utility>
#include "UniquePtr.h"
#include "SharedPtr.h"
#include "MakeShared.h"
#include "Token.h"
#include "RingBuffer.h"

class Test {

    std::string _value;

public:
    explicit Test(std::string value) : _value(std::move(value)) { }

    ~Test() {
        std::cout << "Test deleted" << std::endl;
    }

    std::string& content() { return _value; }
};


UniquePtr<Test> create_test() {
    return UniquePtr<Test>::make_unique("Hello world");
}

//void use_test(UniquePtr<Test> test) {
void use_test(SharedPtr<Test> test) {
    std::cout << "Using Test: '" << test->content() << "'" << std::endl;
}





int main() {


    { // Use
        auto t = make_shared<Test>("Hello world");
        std::cout << t->content() << std::endl;
    }
    std::cout << "Test 1" << std::endl;

    { // Copy
        auto t = make_shared<Test>("Hello world");
        use_test(t);
        std::cout << t->content() << std::endl;
    }
    std::cout << "Test 2" << std::endl;

    { // Move
        auto t = make_shared<Test>("Hello world");
        use_test(std::move(t));
        std::cout << "Should be freed" << std::endl;
//        std::cout << t->content() << std::endl;
    }
    std::cout << "Test 2" << std::endl;


    {
        Token t("Hello world", 5, 5, 10);
        std::cout << t.get_length() << ": " << t.get_lexem() << std::endl;
    }

    std::vector<SharedPtr<Token>> tokens;

    tokenize("hello 123 world\0", tokens);

    for (const SharedPtr<Token>& t : tokens) {
        std::cout << "Token @" << t->get_row() << ":" << t->get_column() << " [" << t->get_lexem() << "]" << std::endl;
    }

    RingBuffer b(5);
    b.writeBuffer(tokens[0]);
    b.writeBuffer(tokens[0]);
    b.writeBuffer(tokens[0]);
    b.writeBuffer(tokens[0]);
    b.writeBuffer(tokens[0]);

    std::cout << "expect Buffer full" << std::endl;
    b.writeBuffer(tokens[0]);
    std::cout << "Remove and add" << std::endl;

    (void)b.readBuffer();
    (void)b.readBuffer();
    b.writeBuffer(tokens[0]);
    b.writeBuffer(tokens[0]);
    b.writeBuffer(tokens[0]);

    std::cout << "Done!" << std::endl;
    return 0;
}
