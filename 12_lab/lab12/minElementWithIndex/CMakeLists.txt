project(Lab13)

set(HEADER_FILES
        minElementWithIndex.h
)

set(SOURCE_FILES
        minElementWithIndex.cpp
)

add_library(minElementWithIndex STATIC ${SOURCE_FILES} ${HEADER_FILES})