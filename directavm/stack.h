//
// Created by GilesD on 9/06/2022.
//

#ifndef DIRECTAVM_STACK_H
#define DIRECTAVM_STACK_H

#endif //DIRECTAVM_STACK_H

#include <limits.h>
#include <stdio.h>
#include <stdlib.h>

#include "types.h"

#define STACK_BEGIN -1

typedef struct {
    unsigned stackPointer;
    unsigned currentCapacity;
    unsigned originalCapacity;
    void** array;
} Stack;

Stack* stack_create(unsigned capacity);
void stack_destroy(Stack* stack);
void stack_push(Stack* stack, void* object);
void* stack_pop(Stack*);
int stack_is_full(Stack* stack);
void stack_dump(Stack* stack);
void stack_extend(Stack* stack);

