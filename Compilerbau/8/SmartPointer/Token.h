//
// Created by Colin on 16.12.2025.
//

#ifndef SMARTPOINTER_TOKEN_H
#define SMARTPOINTER_TOKEN_H


#include <string>
#include <vector>
#include <memory>
#include "SharedPtr.h"

class Token {
public:
    /**
     * Constructs a new token object.
     *
     * @param l is a pointer to the text of the token (to be copied)
     * @param r is the row in input where this token was found
     * @param c is the column in input where this token starts
     */
    Token(const char* l, size_t length, int r, int c);

    Token(const Token& p);

    Token &operator=(const Token &t);

    /**
     * Destructs the token object and free's the stored lexem.
     */
    ~Token();

    size_t get_length() const;

    std::string get_lexem() const;

    bool is_eof() const;

    int get_row() const;

    int get_column() const;

private:
    char* lexem;    ///< Pointer to the text of the token
    int row;        ///< Row in input where this token was found
    int col;        ///< Column in input where this token starts
};


class Lexer {

public:
    Lexer(const char* buffer) : char_buffer(buffer), position(0), row(0), column(0) {}

    Token next_token();

private:

    char peek();
    void consume();
    void WS();
    Token Number();
    Token Word();

    const char* char_buffer;
    size_t position;
    int row;
    int column;

};



void tokenize(const std::string& input, std::vector<Token>& tokens);


#endif //SMARTPOINTER_TOKEN_H
