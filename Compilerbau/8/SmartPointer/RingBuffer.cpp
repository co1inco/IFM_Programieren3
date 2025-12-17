//
// Created by Colin on 17.12.2025.
//

#include "RingBuffer.h"
#include <iostream>

RingBuffer::RingBuffer(unsigned int size) : count(0), head(0), size(size) {
    elems = new SharedPtr<Token>[size];
}


RingBuffer::~RingBuffer() {
    delete[] elems;
}

auto RingBuffer::readBuffer() -> SharedPtr<Token> {
    if (count == 0)
        return SharedPtr<Token>(nullptr);

    auto index = head++ % size;
    count--;

    return elems[index];
}

auto RingBuffer::writeBuffer(const SharedPtr<Token> &data) -> void {

    if (count == size){
        std::cout << "Buffer full" << std::endl;qqq

        return;
    }

    auto index = (head + count++) % size;
    elems[index] = SharedPtr<Token>(data);
}