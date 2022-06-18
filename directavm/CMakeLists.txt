cmake_minimum_required(VERSION 3.22)
project(directavm C)

set(CMAKE_C_STANDARD 99)

add_executable(directavm main.c stack.h stack.c types.h valuetype.h instructions.h machine.h)
