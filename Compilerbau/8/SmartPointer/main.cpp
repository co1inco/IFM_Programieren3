#include <iostream>
#include <memory>
#include <utility>
#include "UniquePtr.h"
#include "SharedPtr.h"
#include "MakeShared.h"

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




    std::cout << "Done!" << std::endl;
    return 0;
}
