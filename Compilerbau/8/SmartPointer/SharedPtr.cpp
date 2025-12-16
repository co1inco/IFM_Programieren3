//
// Created by Colin on 16.12.2025.
//
#include "SharedPtr.h"


RefCounter::RefCounter() : n(1) {}

bool RefCounter::isZero() const {
    return n <= 0;
}

void RefCounter::dec() {
    n--;
}

void RefCounter::inc() {
    n++;
}
