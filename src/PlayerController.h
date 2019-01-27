#ifndef PLAYERCONTROLLER_H
#define PLAYERCONTROLLER_H

#include "Game.h"
#include "Player.h"
#include "Container.h"

class PlayerController
{
  private:
    Player * player;
  
    int speedX;
    int speedY;
    // int pressedButtons[4];

    bool consoleMode;
    int * pressedButtons;

  public:
    PlayerController(Player *p) : player(p){ speedX = 0; speedY = 0; consoleMode = false; pressedButtons = new int[200];}
    ~PlayerController(){ delete pressedButtons;}

    void handleKeyboard(int eventType, const EmscriptenKeyboardEvent *e, void *userData)
    {
        char c = e->key[0];
        if (eventType == 2)  pressedButtons[c] = 1;
        else  pressedButtons[c] = 0;
    }

    void handleMouse(int eventType, const EmscriptenMouseEvent *mouseEvent, void *userData) {}
    void update(Container<Object>* objectContainer,int elapsedTime)
    {

        if(pressedButtons[66] == 1) consoleMode = false; //Backspace
        if(consoleMode) return;

        if(pressedButtons[119] == 1) speedY = -player->getSpeed(); //w
        if(pressedButtons[115] == 1) speedY = player->getSpeed(); //s
        if(pressedButtons[97] == 1) speedX = -player->getSpeed(); //a
        if(pressedButtons[100] == 1) speedX = player->getSpeed(); //d

        // if (speedY == 0 && speedX == 0) return;

        if (!player->isBlocked(
                player->getPosition()->getX() + speedX,
                player->getPosition()->getY() + speedY,
                objectContainer->getAll(),
                objectContainer->getSize()))
        {
            player->move(speedX, speedY, elapsedTime);
        }
        else  player->move(0, 0, elapsedTime);
        
        if (speedY != 0 || speedX != 0) speedX = speedY = 0;
    }
    int* getPressedKeys(){ return pressedButtons;}
    void setConsoleMode(bool active){ consoleMode = active;}
};

#endif