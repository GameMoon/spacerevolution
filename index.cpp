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

#include "src/Screen.h"
#include "src/Player.h"

const int WIDTH = 1920;
const int HEIGHT = 1080;


Screen * screen;
Image * images;
int numberOfImages = 0;

//int screenMem1 [1024][768][3];
//int screenMem2 [720][480][3];

int posX = 61;
int posY = 183;
int pressedButtons[4];

extern "C"
{
    EM_BOOL key_callback(int eventType, const EmscriptenKeyboardEvent *e, void *userData)
    {
        // printf("%s | %d\n", e->code, eventType);
        
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
        return screen->getPixels();
    }

    EMSCRIPTEN_KEEPALIVE int getScreenWidth()
    {
        return screen->getWidth();
    }
    EMSCRIPTEN_KEEPALIVE int getScreenHeight()
    {
        return screen->getHeight();
    }
    EMSCRIPTEN_KEEPALIVE void addImage(int pointerValue, int width, int height)
    {
        uint8_t *pointer = ((uint8_t *)(intptr_t)(pointerValue));
        images[numberOfImages].setPixels(pointer);
        images[numberOfImages].setSize(width,height);
        numberOfImages++;
    }

    EM_JS(void, render, (), {
        Module.renderImageFromMemory();
    });

    EM_JS(void, renderSetup, (), {
        Module.renderSetup();
    });

    EM_JS(void, loadImage, (const char *str),{
        loadImage(UTF8ToString(str));
    });

    EMSCRIPTEN_KEEPALIVE void startgame()
    {
        printf("startgamesdfsdf\n");
    }
}


Player * p;
void updateLoop()
{
    if(numberOfImages == 0) return;
    else if(numberOfImages == 1){
        printf("Images loaded\n");
       
        numberOfImages++;
        p = new Player(new Vector2(10, 10), &images[0]);
    }
    else if(numberOfImages == 2){
    
        //Movement update
        if(pressedButtons[0] == 1) posY-=5;
        if(pressedButtons[1] == 1) posY+=5;
        if(pressedButtons[2] == 1) posX-=5;
        if(pressedButtons[3] == 1) posX+=5;

        p->move(posX,posY);
        
        // if(posX > 1037) posX=1037;
        // if(posX < 61) posX=61;
        // if(posY > 903) posY=903;
        // if(posY < 183) posY=183;
        
        //Render
        screen->clearArea1();
        screen->clearArea2();
        p->draw(screen);
        render();
    }
}


int main(void)
{
    screen = new Screen(WIDTH,HEIGHT);
    images = new Image[5];

    renderSetup();
    loadImage("assets/Ninja.png");
    
    //Keypress handling
    emscripten_set_keydown_callback(0, 0, 1, key_callback);
    emscripten_set_keyup_callback(0, 0, 1, key_callback);

    //Main loop handler
    emscripten_set_main_loop(updateLoop, 0, 1);
}



