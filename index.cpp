#include <stdio.h>
#include <emscripten/emscripten.h>

int main(void)
{
     printf("Hello world C++\n");
}


extern "C"
{
    EMSCRIPTEN_KEEPALIVE int myFunction(int test)
    {
        printf("MyFunction Called\n");
        return test*test;
    }
}
