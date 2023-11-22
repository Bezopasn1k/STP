#ifndef MIN_ELEMENT_WITH_INDEX_H
#define MIN_ELEMENT_WITH_INDEX_H

#include <vector>

struct MinElementResult {
    int value;
    int index;
};

MinElementResult findMinElement(const std::vector<int>& arr);
void one();

#endif