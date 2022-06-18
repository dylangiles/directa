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

typedef struct {
    unsigned stackPointer;
    unsigned currentCapacity;
    unsigned originalCapacity;
    uint8_t* array;
} EvaluationStack;

Stack* stack_create(unsigned capacity);
void stack_destroy(Stack* stack);
void stack_push(Stack* stack, void* object);
void* stack_pop(Stack*);
int stack_is_full(Stack* stack);
void stack_dump(Stack* stack);
void stack_extend(Stack* stack);

EvaluationStack* eval_stack_create(unsigned capacity);
void eval_stack_destroy(EvaluationStack* stack);
void eval_stack_push_int(EvaluationStack* stack, uint64_t value);
void eval_stack_push_float(EvaluationStack* stack, double value);
uint64_t eval_stack_pop_int(EvaluationStack* stack);
void eval_stack_push_byte(EvaluationStack* stack, uint8_t value);



