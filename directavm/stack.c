

#include <string.h>

#include "stack.h"

Stack* stack_create(unsigned capacity) {
    // Allocate the stack object itself
    Stack* stack = (Stack*)malloc(sizeof(Stack));
    stack->originalCapacity = capacity;
    stack->currentCapacity = capacity;
    stack->stackPointer = STACK_BEGIN;

    // Allocate bytes equal to currentCapacity times size of a void pointer.
    stack->array = (void**)malloc(stack->currentCapacity * sizeof(void*));

    return stack;
}

void stack_destroy(Stack* stack) {
    free(stack->array);
    free(stack);
}

void stack_push(Stack* stack, void* object) {
    stack->stackPointer += 1;
    stack->array[stack->stackPointer] = object;
}

void* stack_pop(Stack* stack) {
    void* result = stack->array[stack->stackPointer];
    stack->stackPointer -= 1;
    return result;
}

int stack_is_full(Stack* stack) {
    return stack->stackPointer == stack->currentCapacity;
}

void stack_dump(Stack* stack) {
    printf("### Value stack dump ###\n\n");
    printf("\tStack grows towards higher addresses.\n");
    printf("\tStack currentCapacity: %d\n", stack->currentCapacity);
    printf("\tCurrent stack pointer: %d\n\n", stack->stackPointer);

    for(int i = 0; i < stack->currentCapacity; i++) {
        int* pointer = stack->array[i];
        int value = *pointer;
        printf("Item at stack index [%d]: %d\n", i, value);
    }

    printf("\n### End of value stack dump ###\n\n");
}

void stack_extend(Stack* stack) {
    void** saveBuffer = (void**)malloc(stack->currentCapacity * sizeof(void*));
    int saveBufferSize = sizeof(saveBuffer);
    for(int i = 0;i < sizeof(saveBuffer); i++) {

    }

    stack->currentCapacity = stack->currentCapacity + stack->originalCapacity;
    void* unused = realloc(stack->array, stack->currentCapacity * sizeof(void*));


    for(int i = 0;i < sizeof(saveBuffer); i++) {

    }

    free(saveBuffer);
}

EvaluationStack* eval_stack_create(unsigned capacity) {
    EvaluationStack* evalStack = (EvaluationStack*)malloc(sizeof(EvaluationStack));
    evalStack->currentCapacity = capacity;
    evalStack->originalCapacity = capacity;
    evalStack->stackPointer = STACK_BEGIN;
    evalStack->array = (uint8_t*)malloc(sizeof(uint8_t) * capacity);

    return evalStack;
}

void eval_stack_destroy(EvaluationStack* stack) {
    free(stack->array);
    free(stack);
}

void eval_stack_push_int(EvaluationStack* stack, uint64_t value) {

    for(int i = 0; i < sizeof(uint64_t); i++) {
        stack->stackPointer += 1;

        uint64_t shiftValue = 8 * i;
        uint64_t mask = ((uint64_t)0xFF) << shiftValue;
        uint8_t byteValue = (uint8_t)((value & mask) >> shiftValue);

        stack->array[stack->stackPointer] = byteValue;
    }
}

void eval_stack_push_float(EvaluationStack* stack, double value) {
    uint8_t bytes[sizeof(double)];

    // TODO: find a portable way to do this.
    // works by treating the double as a pointer to an array of sizeof(double) uint8_t's
    // and memcpy()'s that "byte array" to the stack
    // eval_stack_push_int is ALWAYS little-endian, endian-ness of the float will be machine defined.
    memcpy(bytes, (uint8_t*) &value, sizeof(double));
    for(int i = 0; i < sizeof(double); i++) {
        stack->stackPointer += 1;
        stack->array[stack->stackPointer] = bytes[i];
    }
}

void eval_stack_push_byte(EvaluationStack* stack, uint8_t value) {
    stack->stackPointer += 1;
    stack->array[stack->stackPointer] = value;
}
