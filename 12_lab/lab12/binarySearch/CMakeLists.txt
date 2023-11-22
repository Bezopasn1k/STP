project(Lab13)

set(HEADER_FILES
        binarySearch.h
)

set(SOURCE_FILES
        binarySearch.cpp
)

add_library(binarySearch STATIC ${SOURCE_FILES} ${HEADER_FILES})