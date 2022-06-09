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

typedef struct Stack {
    unsigned stackPointer;
    unsigned currentCapacity;
    unsigned originalCapacity;
    void** array;
};

struct Stack* stack_create(unsigned capacity);
void stack_destroy(struct Stack* stack);
void stack_push(struct Stack* stack, void* object);
void* stack_pop(struct Stack*);
int stack_is_full(struct Stack* stack);
void stack_dump(struct Stack* stack);
void stack_extend(struct Stack* stack);

