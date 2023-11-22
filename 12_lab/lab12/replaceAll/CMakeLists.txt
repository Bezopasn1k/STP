project(Lab13)

set(HEADER_FILES
        replaceAll.h
)

set(SOURCE_FILES
        replaceAll.cpp
)

add_library(replaceAll STATIC ${SOURCE_FILES} ${HEADER_FILES})