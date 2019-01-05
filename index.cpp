#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <emscripten/emscripten.h>

const int WIDTH = 800;
const int HEIGHT = 600;

const int SIZE = WIDTH * HEIGHT * 4;

uint8_t data[SIZE];

int main(void)
{
     printf("Hello world C++\n");
    //  {for(int k = 0; k <SIZE;k++){
    //      data[k] = k;
    //  }}
}



extern "C"
{
    EMSCRIPTEN_KEEPALIVE int myFunction(int test)
    {
        printf("MyFunction Called\n");
        return test*test;
    }

    EMSCRIPTEN_KEEPALIVE void update(int value)
    {
        uint8_t color = 0;
        int r = 0;
        for (int i = 0; i < SIZE; i+=4)
        {
            r = rand() % 2;
            
            if(r == 0) color = 0;
            else color = 255;

            data[i] = color;
            data[i + 1] = color;
            data[i + 2] = color;
            data[i+3] = 255;
        }
    }

    EMSCRIPTEN_KEEPALIVE uint8_t *getMemoryOffset()
    {
        return &data[0];
    }

    EMSCRIPTEN_KEEPALIVE int getScreenWidth()
    {
        return WIDTH;
    }
    EMSCRIPTEN_KEEPALIVE int getScreenHeight()
    {
        return HEIGHT;
    }
}
