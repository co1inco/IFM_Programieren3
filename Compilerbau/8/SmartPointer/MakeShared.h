//
// Created by Colin on 16.12.2025.
//

#ifndef SMARTPOINTER_MAKESHARED_H
#define SMARTPOINTER_MAKESHARED_H

#include "SharedPtr.h"
#include "UniquePtr.h"

template <class T, class... Params>
static SharedPtr<T> make_shared(Params&&... Args) {
    return SharedPtr<T>(new T(std::forward<Params>(Args)...));
}

#endif //SMARTPOINTER_MAKESHARED_H
