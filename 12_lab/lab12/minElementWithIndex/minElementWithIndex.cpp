#include "minElementWithIndex.h"

#include <iostream>
#include <vector>
#include <cmath>

MinElementResult findMinElement(const std::vector<int>& arr) {
    if (arr.empty()) {
        return {0, -1};
    }

    int minVal = arr[0];
    int minIndex = 0;

    for (int i = 1; i < arr.size(); ++i) {
        if (arr[i] < minVal) {
            minVal = arr[i];
            minIndex = i;
        }
    }

    return {minVal, minIndex};
}

void one() {
    std::cout << "1.    Отыскать минимальный элемент одномерного массива\n"
                 "      целых, его значение и значение его индекса" << std::endl << std::endl;

    int eta = 4;
    int n1 = 9;
    int n2 = 7;
    int n = n1 + n2;

    int N1 = 21;
    int N2 = 22;
    int N = N1 + N2;

    int S = 15;

    // потенциальный объем реализации
    double VV = (2 + eta) * std::log2(2 + eta);         // в битах

    // объём реализации
    double V = N * std::log2(n);                        // в битах

    // уровень программы через потенциальный объем
    double L = VV / V;

    // уровень программы по реализации
    double LL = (static_cast<double>(n1) / N1) * (static_cast<double>(n2) / N2);

    // интеллектуальное содержание программы
    double I = LL * V;

    // прогнозируемое время написания программы, выраженное через потенциальный объем
    double T1 = (V * V) / (S * VV);

    // прогнозируемое время написания программы, выраженное через длину реализации, найденную по Холстеду
    double T2 = (n2 * N2 * (n1 * std::log2(n1) + n2 * std::log2(n2)) * std::log2(n)) / (2 * S * n2);

    // прогнозируемое время написания программы, выраженное через метрические характеристики реализации
    double T3 = (n1 * N2 * N * std::log2(n)) / (2 * S * n2);

    // среднее значение уровня языка программирования
    double l = L * L * V;

    std::cout << "Потенциальный объем реализации (VV): " << VV << std::endl;
    std::cout << "Объём реализации (V): " << V << std::endl;
    std::cout << "Уровень программы через потенциальный объем (L): " << L << std::endl;
    std::cout << "Уровень программы по реализации (LL): " << LL << std::endl;
    std::cout << "Интеллектуальное содержание программы (I): " << I << std::endl;
    std::cout << "Прогнозируемое время написания программы, выраженное через потенциальный объем (T1): " << T1 << std::endl;
    std::cout << "Прогнозируемое время написания программы, выраженное через длину реализации, найденную по Холстеду (T2): " << T2 << std::endl;
    std::cout << "Прогнозируемое время написания программы, выраженное через метрические характеристики реализации (T3): " << T3 << std::endl;
    std::cout << "Среднее значение уровня языка программирования: " << l << std::endl;
}