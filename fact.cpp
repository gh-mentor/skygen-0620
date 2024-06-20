

#include <iostream>


/*
create a factorial function 'fact' that does not use recursion
arguments:
- n: an unsigned integer
returns:
- an unsigned integer
details:
- uses a for loop to calculate the factorial of n
*/

unsigned int fact(unsigned int n) {
    unsigned int result = 1;
    for (unsigned int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}
