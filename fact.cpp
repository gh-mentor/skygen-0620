

#include <iostream>


/*
create a factorial function 'fact' that does not use recursion
details:
- takes an unsigned integer 'n' as input
- returns an unsigned integer
*/

unsigned int fact(unsigned int n) {
    unsigned int result = 1;
    for (unsigned int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}
