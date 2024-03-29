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

-s TOTAL_MEMORY=30015488
*/
#include <stdio.h>
#include <stdlib.h>

#include <emscripten/emscripten.h>
#include <emscripten/html5.h>

#include "src/Game.h"

Game * game;

//Callbacks
extern "C"
{
    EM_BOOL static handleKeyboard(int eventType, const EmscriptenKeyboardEvent *e, void *userData)
    {
        // printf("%s | %d\n", e->code, eventType);
        game->getPlayerController()->handleKeyboard(eventType, e, userData);
        return true;
    }
    EM_BOOL handleMouse(int eventType, const EmscriptenMouseEvent *e, void *userData)
    {
        //printf("%s | %d\n", mouseEvent->code, eventType);
        game->getPlayerController()->handleMouse(eventType, e, userData);
        return true;
    }
    EMSCRIPTEN_KEEPALIVE uint8_t * getMemoryOffset()
    {
        return game->getScreen()->getPixels();
    }

    EMSCRIPTEN_KEEPALIVE int getScreenWidth()
    {
        return game->getScreen()->getWidth();
    }
    EMSCRIPTEN_KEEPALIVE int getScreenHeight()
    {
        return game->getScreen()->getHeight();
    }

    EMSCRIPTEN_KEEPALIVE void addImage(int pointerValue, int width, int height,int id)
    {
       game->loadImage(pointerValue,width,height,id);
    }
    EMSCRIPTEN_KEEPALIVE void addMap(int pointerValue)
    {
       game->loadMap(pointerValue);
    }

    EM_JS(void, render, (), {
        Module.renderImageFromMemory();
    });

    EM_JS(void, renderSetup, (), {
        Module.renderSetup();
    });
}

void updateLoop()
{
    game->update();
    render();
}


int main(void)
{  
    game = new Game();
    renderSetup();

    //Callback setup
    emscripten_set_keydown_callback(0, 0, 1, handleKeyboard);
    emscripten_set_keyup_callback(0, 0, 1, handleKeyboard);
    emscripten_set_click_callback(0,0,0,handleMouse);

    //Main loop handler
    emscripten_set_main_loop(updateLoop, -1, 1);
}



