project(Lab13)

set(HEADER_FILES
        bubbleSort.h
)

set(SOURCE_FILES
        bubbleSort.cpp
)

add_library(bubbleSort STATIC ${SOURCE_FILES} ${HEADER_FILES})