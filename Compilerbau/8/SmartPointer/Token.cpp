//
// Created by Colin on 16.12.2025.
//

#include "Token.h"
#include "SharedPtr.h"
#include "MakeShared.h"
#include <string.h>
#include <memory>
#include <iostream>


Token::Token(const char *l, size_t length, int r, int c)
    : lexem(nullptr), row(r), col(c) {
    const size_t len = strlen(l);
//    std::cout << "Token created " << len << std::endl;
    lexem = new char[length + 1];
    strncpy_s(lexem, length + 1, l, length);
}

Token::~Token() {
//    std::cout << "Token deleted" << std::endl;
    delete[] lexem;
}

size_t Token::get_length() const {
    return strlen(lexem);
}

std::string Token::get_lexem() const {
    return { lexem };
}

bool Token::is_eof() const {
    return lexem[0] == '\0';
}

int Token::get_column() const {
    return col;
}

int Token::get_row() const {
    return row;
}

Token &Token::operator=(const Token &t) {

    delete[] lexem;

    auto length = strlen(t.lexem);
    char* temp = new char[length + 1];
    lexem = temp;
    strncpy_s(lexem, length + 1, t.lexem, length);

    row = t.row;
    col = t.col;

    return *this;
}

Token::Token(const Token &p) {

    auto length = strlen(p.lexem);
    lexem = new char[length + 1];
    strncpy_s(lexem, length + 1, p.lexem, length);

    row = p.row;
    col = p.col;
}


void tokenize(const std::string &input, std::vector<SharedPtr<Token>> &tokens) {

    Lexer lexer(input.c_str());

    SharedPtr<Token> t = lexer.next_token();
    while (!t->is_eof())
    {
        tokens.push_back(t);
        t = lexer.next_token();
    }
}

SharedPtr<Token> Lexer::next_token() {
    while (peek() != '\0') {
        switch (peek()) {
            case ' ':
            case '\t':
            case '\r':
            case '\n':
                WS();
                continue;
        }

        if (peek() >='0' && peek() <= '9')
            return Number();

        if ((peek() >= 'a' && peek() <= 'z') || (peek() >= 'A' && peek() <= 'Z'))
            return Word();

        // throw error
        consume();
    }

    return make_shared<Token>(char_buffer, 1, row, column);
}

void Lexer::consume() {
    if (*char_buffer == '\n')
    {
        row++;
        column = 0;
    }
    else {
        column++;
    }

    position++;
    char_buffer++;
}

char Lexer::peek() {
    return *char_buffer;
}

void Lexer::WS() {
    while (peek() == ' ' || peek() == '\t' || peek() == '\r' || peek() == '\n') {
        consume();
    }
}

SharedPtr<Token> Lexer::Number() {
    auto r = row;
    auto c = column;
    auto b = char_buffer;
    auto p = position;

    while (peek() >='0' && peek() <= '9') {
        consume();
    }

    auto t = make_shared<Token>(b, position - p, r, c);
    return t;
}

SharedPtr<Token> Lexer::Word() {
    auto r = row;
    auto c = column;
    auto b = char_buffer;
    auto p = position;

    while ((peek() >= 'a' && peek() <= 'z') || (peek() >= 'A' && peek() <= 'Z')) {
        consume();
    }

    return make_shared<Token>(b, position - p, r, c);
}
