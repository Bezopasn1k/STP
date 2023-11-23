#include <iostream>
#include <set>

template <class T>

class TSetInheritance : public std::set<T> {
public:
    // конструктор
    TSetInheritance() = default;
    // опустошить
    void clear() {
        std::set<T>::clear();
    }
    // добавить
    void add(const T& item) {
        std::set<T>::insert(item);
    }
    // удалить
    void remove(const T& item) {
        std::set<T>::erase(item);
    }
    // пусто?
    bool isEmpty() {
        return std::set<T>::empty();
    }
    // принадлежит?
    bool contains(const T& item) const {
        return std::set<T>::find(item) != std::set<T>::end();
    }
    // объединить
    TSetInheritance<T> unionWith(const TSetInheritance<T>& q) {
        TSetInheritance<T> result = *this;
        for (const T& item : q) {
            result.add(item);
        }
        return result;
    }
    // вычесть
    TSetInheritance<T> subtract(const TSetInheritance<T>& q) {
        TSetInheritance<T> result = *this;
        for (const T& item : q) {
            result.remove(item);
        }
        return result;
    }
    // умножить
    TSetInheritance<T> intersect(const TSetInheritance<T>& q) {
    TSetInheritance<T> result;
    for (const T& item : *this) {
        if (q.contains(item)) {
            result.add(item);
        }
    }
    return result;
    }
    // количество элементов
    int size() {
        return std::set<T>::size();
    }
    // элемент
    T getElement(int j) {
        auto it = std::set<T>::begin();
        std::advance(it, j);
        return *it;
    }
}; 
