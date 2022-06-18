#include <stdio.h>

#include "stack.h"

int main() {
    EvaluationStack* evalStack = eval_stack_create(sizeof(uint64_t) * 3);

//    eval_stack_push_int(evalStack, 0x0102030405060708);
    eval_stack_push_float(evalStack, 1.456);
    printf("");

    eval_stack_destroy(evalStack);
}
