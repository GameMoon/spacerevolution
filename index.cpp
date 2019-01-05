#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <math.h>
#include <emscripten/emscripten.h>

const int WIDTH = 800;
const int HEIGHT = 600;

const int SIZE = WIDTH * HEIGHT * 4;

uint8_t data[SIZE];


extern "C"
{
    EMSCRIPTEN_KEEPALIVE uint8_t * getMemoryOffset()
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

    EM_JS(void, render, (), {
        Module.renderImageFromMemory();
    });
   
}

void setPixel(int x, int y, int r, int g, int b)
{
    int offset = (x + y * WIDTH) * 4;
    data[offset] = r;
    data[offset + 1] = g;
    data[offset + 2] = b;
    data[offset + 3] = 255;
}

void rotate(int x, int y,int centerX, int centerY, float omega)
{
    float translatedX = (x - centerX) * cos(omega) - (y - centerY) * sin(omega);
    float translatedY = (x - centerX) * sin(omega) + (y - centerY) * cos(omega);

    setPixel(translatedX+centerX, translatedY+centerY, 200, 0, 0);
}

void drawRectangle(int x, int y, int width, int height, float omega = 0.0f)
{
    int centerX = x+width/2;
    int centerY = y + height /2;
    for (int xOffset = 0; xOffset < width; xOffset++)
    {
        for (int yOffset = 0; yOffset < height; yOffset++)
        {
            rotate(x + xOffset, y + yOffset, centerX, centerY, omega);
        }
    }
}

void clearScreen(){
    for (int i = 0; i < SIZE; i += 4)
    {
        data[i] = 255;
        data[i + 1] = 255;
        data[i + 2] = 255;
        data[i + 3] = 255;
    }
}

int startPos = 10;
float omega = 0.78f;
void updateLoop()
{
    
    clearScreen();

    drawRectangle(100, 100, 48, 48, 0.0);

    drawRectangle(startPos, 50, 48, 48, omega);

    omega += 0.1f;
    startPos += 2;

    render();
}

int main(void)
{
    emscripten_set_main_loop(updateLoop, 0, 1);
}



