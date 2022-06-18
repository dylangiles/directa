//
// Created by Dylan Giles on 11/6/2022.
//

#ifndef DIRECTAVM_VALUETYPE_H
#define DIRECTAVM_VALUETYPE_H

#endif //DIRECTAVM_VALUETYPE_H

#include <stdint.h>

typedef struct {
    union {
        uint8_t raw[8];

    };

} DirectaValueType;