

#include <iostream>


unsigned int fact(unsigned int n);


int main(){


    for (unsigned int i = 0; i < 10; ++i) {
        std::cout << i << "! = " << fact(i) << std::endl;
    
    return 0;
    }
}

unsigned int fact(unsigned int n) {
    unsigned int result = 1;
    for (unsigned int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}
