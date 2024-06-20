

#include <iostream>


unsigned int fact(unsigned int n);


int main(){


    for (unsigned int i = 0; i < 10; ++i) {
        std::cout << i << "! = " << fact(i) << std::endl;
    
    return 0;
    }
}

/**
 * Calculates the factorial of a given number.
 *
 * @param n The number for which the factorial is to be calculated.
 * @return The factorial of the given number.
 */
unsigned int fact(unsigned int n) {
    unsigned int result = 1;
    for (unsigned int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}

/**
 * Calculates the permutation of n and k.
 * 
 * @param n The number of elements.
 * @param k The number of elements to choose.
 * @return The permutation of n and k.
 * @example perm(5, 3) = 60
 *
 * */
unsigned int perm(unsigned int n, unsigned int k) {
    unsigned int result = 1;
    for (unsigned int i = n - k + 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}
