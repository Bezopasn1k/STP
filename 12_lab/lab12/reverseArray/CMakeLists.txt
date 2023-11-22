project(Lab13)

set(HEADER_FILES
        reverseArray.h
)

set(SOURCE_FILES
        reverseArray.cpp
)

add_library(reverseArray STATIC ${SOURCE_FILES} ${HEADER_FILES})