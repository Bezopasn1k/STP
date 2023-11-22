#include "binarySearch.h"

#include <iostream>
#include <cmath>

int binarySearch(int arr[], int n, int target) {
    int left = 0;
    int right = n - 1;

    while (left <= right) {
        int mid = left + (right - left) / 2;

        if (arr[mid] == target) {
            return mid;
        } else if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    return -1;
}

void three() {
    std::cout << "3.    Бинарный поиск элемента в упорядоченном одномерном\n"
                 "      массиве" << std::endl << std::endl;

    int eta = 7;
    int n1 = 16;
    int n2 = 12;
    int n = n1 + n2;

    int N1 = 31;
    int N2 = 28;
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

    std::cout << "Potential sales volume (VV): " << VV << std::endl;
    std::cout << "Implementation volume (V): " << V << std::endl;
    std::cout << "Program level through potential volume (L): " << L << std::endl;
    std::cout << "Program implementation level (LL): " << LL << std::endl;
    std::cout << "Intellectual content of the program (I): " << I << std::endl;
    std::cout << "Predicted time to write a program, expressed in terms of potential volume (T1): " << T1 << std::endl;
    std::cout << "Predicted time to write a program, expressed in terms of the implementation length found by Halstead (T2): " << T2 << std::endl;
    std::cout << "Predicted time to write a program, expressed through metric implementation characteristics (T3): " << T3 << std::endl;
    std::cout << "Average programming language level: " << l << std::endl;
}