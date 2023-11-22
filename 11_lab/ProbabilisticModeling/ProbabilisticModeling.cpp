#define _USE_MATH_DEFINES
#include <math.h>
#include <iostream>
#include <vector>
#include <set>
#include <string>
#include <random>
#include <cmath>
#include <ctime>
#include <windows.h>

std::mt19937 rng(std::random_device{}());

std::string getRandomWord(const std::vector<std::string>& dictionary) {
    std::uniform_int_distribution<int> dist(0, dictionary.size() - 1);
    int randomIndex = dist(rng);

    return dictionary[randomIndex];
}

std::vector<std::string> generateDictionary(int size) {
    std::vector<std::string> dictionary;

    for (int i = 0; i < size; ++i) {
        dictionary.push_back("codeWord" + std::to_string(i));
    }

    return dictionary;
}

int simulateProgramming(int size) {
    std::srand(static_cast<unsigned>(std::time(nullptr)));

    std::vector<std::string> dictionary = generateDictionary(size);
    std::set<std::string> usedCodeWords;

    int programLength = 0;

    while (usedCodeWords.size() < dictionary.size()) {
        std::string randomWord = getRandomWord(dictionary);

        if (usedCodeWords.find(randomWord) == usedCodeWords.end()) {
            usedCodeWords.insert(randomWord);
        }

        programLength++;
    }

    return programLength;
}

int main() {
    SetConsoleOutputCP(CP_UTF8);

    int dictSizes[4] = { 16, 32, 64, 128 };

    for (int& dictSize : dictSizes) {
        int totalLength = 0;
        int countTests = 5000;

        double expectedLength = 0.9 * dictSize * log2(dictSize);
        double disp = 0;

        for (int j = 0; j < countTests; ++j) {
            int currentLength = simulateProgramming(dictSize);
            disp += (pow(currentLength - expectedLength, 2));
            totalLength += currentLength;
        }
        disp = disp / countTests;

        double averageLength = static_cast<double>(totalLength) / countTests;

        double variance = (M_PI * M_PI * dictSize * dictSize) / 6.0;
        double relativeError = 1.0 / (2.0 * log2(dictSize));


        std::cout << "-> Dictionary length: " << dictSize << std::endl;
        std::cout << "-> Program length(real | theoretical) : " << averageLength << " | " << expectedLength
            << std::endl;
        std::cout << "-> Length dispersion (real | theoretical): " << disp << " | " << variance << std::endl;
        std::cout << "-> Standard deviation(real | theoretical) : " << sqrt(disp) << " | "
            << sqrt(variance) << std::endl;
        std::cout << "-> Relative expected error (real | theoretical): " << sqrt(disp) / averageLength
            << " | " << relativeError << std::endl;
        std::cout << std::endl;
    }

    int nProg = 87;
    int lengthProg = 437;
    double expectedLengthProg = 0.9 * nProg * log2(nProg);

    std::cout << "Length of the written program dictionary: " << nProg << std::endl;
    std::cout << "Program length (real | theoretical): " << lengthProg << " | " << expectedLengthProg << std::endl;
    std::cout << std::endl;

    int n2_ext = 11;
    double n2 = n2_ext * log2(n2_ext);
    double dictSize = 2 * n2;

    double expLength = 0.9 * dictSize * log2(dictSize);

    std::cout << "Length of the written program dictionary in n2*: " << nProg << std::endl;
    std::cout << "Program length in terms of n2* (real | theoretical): " << lengthProg << " | " << expLength << std::endl;

    return 0;
}
