#include <stdio.h>

#include "stack.h"

int main() {
    Stack* stack = stack_create(3);
    int number1 = 123;
    int number2 = 456;
    int number3 = 789;

    stack_push(stack, &number1);
    stack_push(stack, &number2);
    stack_push(stack, &number3);

    printf("Before extend\n");
    stack_dump(stack);

    stack_extend(stack);

    printf("After extend\n");
    stack_dump(stack);

    stack_destroy(stack);
}
