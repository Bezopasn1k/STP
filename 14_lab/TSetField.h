#include <iostream>
#include <set>

template <class T>

class TSetField {
    private:
        std::set<T> elements;
    public:
    // конструктор
    TSetField() {
        elements.clear();
    }
    // опустошить
    void clear() {
        elements.clear();
    }
    // добавить
    void add(const T& item) {
        elements.insert(item);
    }
    // удалить
    void remove(const T& item) {
        elements.erase(item);
    }
    // пусто?
    bool isEmpty() {
        return elements.empty();
    }
    // принадлежит?
    bool contains(const T& item) const {
        return elements.find(item) != elements.end();
    }
    // объединить
    TSetField unionWith(const TSetField& q) {
        TSetField result;
        for (const T& item : elements) {
            result.add(item);
        }
        for (const T& item : q.elements) {
            result.add(item);
        }
        return result;
    }
    // вычесть
    TSetField subtract(const TSetField& q) {
        TSetField result;
        for (const T& item : elements) {
            if (!q.contains(item)) {
                result.add(item);
            }
        }
        return result;
    }
    // умножить
    TSetField intersect(const TSetField& q) {
        TSetField result;
        for (const T& item : elements) {
            if (q.contains(item)) {
                result.add(item);
            }
        }
        return result;
    }
    // количество элементов
    int size() {
        return elements.size();
    }
    // элемент
    T getElement(int j) {
        auto it = elements.begin();
        std::advance(it, j);
        return *it;
    }
}; 
