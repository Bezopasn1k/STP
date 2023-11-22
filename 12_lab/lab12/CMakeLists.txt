cmake_minimum_required(VERSION 3.26)
project(lab13)

set(CMAKE_CXX_STANDARD 17)

set(SOURCE_FILES main.cpp)
add_executable(Lab13_run ${SOURCE_FILES})

include_directories(minElementWithIndex)
add_subdirectory(minElementWithIndex)

include_directories(bubbleSort)
add_subdirectory(bubbleSort)

include_directories(binarySearch)
add_subdirectory(binarySearch)

include_directories(findMinElement)
add_subdirectory(findMinElement)

include_directories(reverseArray)
add_subdirectory(reverseArray)

include_directories(cyclicShiftLeft)
add_subdirectory(cyclicShiftLeft)

include_directories(replaceAll)
add_subdirectory(replaceAll)

target_link_libraries(Lab13_run minElementWithIndex bubbleSort binarySearch findMinElement reverseArray cyclicShiftLeft replaceAll)