//
// Created by Colin on 16.12.2025.
//

#ifndef SMARTPOINTER_SharedPtr_H
#define SMARTPOINTER_SharedPtr_H

#include <exception>

class RefCounter {
public:
    /**
     * Default constructor
     */
    RefCounter();

    /**
     * Increment count
     */
    void inc();

    /**
     * Decrement count
     */
    void dec();

    /**
     * Compare the counter with zero
     *
     * @return true if n==0, false otherwise
     */
    [[nodiscard]] bool isZero() const;

    // Hide copy constructor and assignment operator
    RefCounter(const RefCounter&) = delete;
    RefCounter& operator=(const RefCounter&) = delete;

private:
    unsigned int n;     ///< How many SmartToken share ownership of "our" object?
};

template <class T>
class SharedPtr {
public:
    /**
     * Constructor
     *
     * Constructs a new smart pointer from a raw pointer, sets the reference
     * counter to 1.
     *
     * @param p is a raw pointer to the token to be shared
     */
    explicit SharedPtr(T* p = nullptr) : pObj(p), rc(new RefCounter) {};

    /**
     * Copy constructor
     *
     * Constructs a new smart pointer from another smart pointer, increments
     * the reference counter.
     *
     * @param sp is another smart pointer
     */
    SharedPtr(const SharedPtr<T>& sp) {
        rc = sp.rc;
        rc->inc();
        pObj = sp.pObj;
    }

//    SharedPtr(SharedPtr<T>&&) noexcept = default;
//
//    SharedPtr& operator=(SharedPtr<T>&&) noexcept = default;

    /**
     * Destructor
     *
     * Decrements the reference counter. If it reaches zero, the shared token
     * will be free'd.
     */
    ~SharedPtr() {
        remove_reference();
    }

    /**
     * Assignment
     *
     * Changes the shared token, thus we need first to perform something like
     * the destructor, followed by something like the constructor.
     *
     * @param sp is another smart pointer
     */
    SharedPtr<T>& operator=(const SharedPtr<T>& sp){
        if (&sp == this)
            return *this;
        if (sp.pObj == this->pObj) // self assignment
            return *this;

//        throw std::exception();
        remove_reference();

        rc = sp.rc;
        rc->inc();
        pObj = sp.pObj;
    }

    /**
     * Dereferences the smart pointer
     *
     * @return a reference to the shared token
     */
    T& operator*() const { return *pObj; }

    /**
     * Dereferences the smart pointer
     *
     * @return a pointer to the shared token
     */
    T* operator->() const { return pObj; };

    /**
     * Comparison
     *
     * @param sp is another smart pointer
     * @return true, if `sp` shares the same token
     */
    bool operator==(const SharedPtr<T>& sp) const { return pObj == sp.pObj; }

private:
    T* pObj;        ///< Pointer to the current shared token
    RefCounter* rc;     ///< Pointer to the reference counter (used for the current token)

    void remove_reference() {
        rc->dec();
        if (rc->isZero()) {
            delete pObj;
            delete rc;
        }
    }
};

//template <class T, class... Params>
//static SharedPtr<T> make_shared(Params&&... Args) {
//    return SharedPtr<T>(new T(std::forward<Params>(Args)...));
//}

#endif //SMARTPOINTER_SHAREDPTR_H
