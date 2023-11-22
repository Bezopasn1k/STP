project(Lab13)

set(HEADER_FILES
        cyclicShiftLeft.h

)

set(SOURCE_FILES
        cyclicShiftLeft.cpp
)

add_library(cyclicShiftLeft STATIC ${SOURCE_FILES} ${HEADER_FILES})