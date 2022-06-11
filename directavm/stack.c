

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