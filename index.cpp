/*
playarea1 is:
1024x768
starting pixel at(top left corner is):
X=61
Y=183
end pixel at(bottom right corner is):
X=1084
Y=950
----------
playarea2 is:
720x480
starting pixel at(top left corner is):
X=1137
Y=75
end pixel at(bottom right corner is):
X=1856
Y=554
*/
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>
#include <math.h>
#include <emscripten/emscripten.h>
#include <emscripten/html5.h>

#include "src/Rectangle.h"

const int WIDTH = 1920;
const int HEIGHT = 1080;

const int SIZE = WIDTH * HEIGHT * 4;

uint8_t data[SIZE];
//int screenMem1 [1024][768][3];
//int screenMem2 [720][480][3];

int posX = 61;
int posY = 183;
int pressedButtons[4];

extern "C"
{
    EM_BOOL key_callback(int eventType, const EmscriptenKeyboardEvent *e, void *userData)
    {
        printf("%s | %d\n", e->code, eventType);
        
        if (strcmp(e->code, "KeyW") == 0){
            if(eventType == 2) 
                pressedButtons[0] = 1;
            else 
                pressedButtons[0] = 0;
        }
        else if(strcmp(e->code,"KeyS")==0){
            if (eventType == 2)
                pressedButtons[1] = 1;
            else
                pressedButtons[1] = 0;
        }
           
        if(strcmp(e->code,"KeyA")==0){
            if (eventType == 2)
                pressedButtons[2] = 1;
            else
                pressedButtons[2] = 0;
        }
        else if(strcmp(e->code,"KeyD")==0){
            if (eventType == 2)
                pressedButtons[3] = 1;
            else
                pressedButtons[3] = 0;
        } 

        return true;
    }
    /*EM_BOOL mouse_callback_func(int eventType, const EmscriptenMouseEvent *mouseEvent, void *userData)
    {
        printf("%s | %d\n", mouseEvent->code, eventType);
            else if(strcmp(mouseEvent->code,"KeyD")==0){
            if (eventType == 2)
                pressedButtons[3] = 1;
            else
                pressedButtons[3] = 0;
        }

    }*/
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
    
    
    EMSCRIPTEN_KEEPALIVE void startgame()
    {
        printf("startgamesdfsdf");
    }
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

int startPos = 1069;

float omega = 0.78f;
void updateLoop()
{
    
    clearScreen();
    if(pressedButtons[0] == 1) posY-=5;
    if(pressedButtons[1] == 1) posY+=5;
    if(pressedButtons[2] == 1) posX-=5;
    if(pressedButtons[3] == 1) posX+=5;
    if(posX > 1037) posX=1037;
    if(posX < 61) posX=61;
    if(posY > 903) posY=903;
    if(posY < 183) posY=183;
    //printf("%d\n", posX);
    //printf("%d\n", posY);

    drawRectangle(posX, posY, 48, 48, 0.0);

    drawRectangle(startPos, 100, 48, 48, omega);
    drawRectangle(startPos, 200, 48, 48, omega);
    drawRectangle(startPos, 300, 48, 48, omega);
    drawRectangle(startPos, 400, 48, 48, omega);

    omega += 0.1f;
    startPos += 2;
    if(startPos > 1876)startPos=1069;
    render();
}

int main(void)
{
 //   emscripten_set_keydown_callback(0, 0, 1, key_callback);
  //  emscripten_set_keyup_callback(0, 0, 1, key_callback);
  //  emscripten_set_main_loop(updateLoop, 0, 1);
    Rectangle rect(Vector2(10,10),100,100);
    rect.draw();
}



