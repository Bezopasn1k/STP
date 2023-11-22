#ifndef FIND_MIN_ELEMENT_H
#define FIND_MIN_ELEMENT_H

#include <vector>

struct MinElement2DArrayResult {
    int value;
    int indexI;
    int indexJ;
};


MinElement2DArrayResult findMinElement(const std::vector<std::vector<int>>& arr);
void four();

#endif