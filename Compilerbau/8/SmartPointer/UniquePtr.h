//
// Created by Colin on 16.12.2025.
//

#ifndef SMARTPOINTER_UNIQUEPTR_H
#define SMARTPOINTER_UNIQUEPTR_H

#include "SharedPtr.h"

template <class T>
class UniquePtr {

    T* _ptr;

public:

    explicit UniquePtr(T* rawPointer) {
        _ptr = rawPointer;
    }

    ~UniquePtr() {
        delete _ptr;
    }

    UniquePtr(const UniquePtr& p) = delete;

    UniquePtr &operator=(const UniquePtr &) = delete;

    UniquePtr(UniquePtr&&) noexcept = default;

    UniquePtr& operator=(UniquePtr&&) noexcept = default;


    template <class... Params>
    static UniquePtr<T> make_unique(Params&&... Args) {
        return UniquePtr<T>(new T(std::forward<Params>(Args)...));
    }

    template <class... Params>
    static SharedPtr<T> make_shared(Params&&... Args) {
       return SharedPtr<T>(new T(std::forward<Params>(Args)...));
    }

    T* ptr() {
        return ptr;
    }

    T* operator->() {
        return _ptr;
    }

    T &operator*() {
        return *_ptr;
    }

};


#endif //SMARTPOINTER_UNIQUEPTR_H
