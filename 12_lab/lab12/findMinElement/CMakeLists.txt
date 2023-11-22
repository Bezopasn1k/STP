project(Lab13)

set(HEADER_FILES
        findMinElement.h
)

set(SOURCE_FILES
        findMinElement.cpp
)

add_library(findMinElement STATIC ${SOURCE_FILES} ${HEADER_FILES})