//
// Created by Dylan Giles on 11/6/2022.
//

#include <stdint.h>
#include <stdio.h>

#ifndef DIRECTAVM_MACHINE_H
#define DIRECTAVM_MACHINE_H

#endif //DIRECTAVM_MACHINE_H

typedef struct {
    FILE* istream;
} Machine;

typedef struct {
    uint8_t opcode;
    int hasAdditionalData;
} Instruction;

int vm_get_instruction(Instruction* outInstruction) {

}