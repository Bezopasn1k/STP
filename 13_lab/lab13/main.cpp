#include <iostream>
#include <cmath>
#include <windows.h>

int main() {
    SetConsoleOutputCP(CP_UTF8);
    int n2_array[] = {300, 400, 512};
    int optimal_n2 = 8;

    for (int n2: n2_array) {
        double k = static_cast<double>(n2) / optimal_n2;

        int i = 0;
        if (k > 8) {
            i = (static_cast<int>(std::log2(n2) / 3)) + 1;
        }

        double K = 1;
        for (int j = 1; j < i; ++j) {
            K += static_cast<double>(n2) / std::pow(8, j);
        }

        double N = K * n2 * std::log2(n2);

        double V = N * std::log2(2 * n2);

        double P = (3 * N) / 8;

        double Tk = P / (5 * 20);

        double B = V / 3000;

        double t = 0.5 / std::log(B);

        std::cout << "Value n2*: " << n2 << std::endl;
        std::cout << "Number of lower level modules: " << k << std::endl;
        std::cout << "Number of hierarchy levels i: " << i << std::endl;
        std::cout << "Number of modules in PS: " << K << std::endl;
        std::cout << "Program length N: " << N << std::endl;
        std::cout << "Volume V PS: " << V << std::endl;
        std::cout << "The length of the syntax in assembler commands P: " << P << std::endl;
        std::cout << "Calendar programming time Tk: " << Tk << std::endl;
        std::cout << "Initial number of errors B: " << B << std::endl;
        std::cout << "PS reliability t: " << t << std::endl << std::endl;
    }

    return 0;
}
