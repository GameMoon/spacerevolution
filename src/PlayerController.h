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
    int pressedButtons[4];

  public:
    PlayerController(Player *p) : player(p){ speedX = 0; speedY = 0;}

    void handleKeyboard(int eventType, const EmscriptenKeyboardEvent *e, void *userData)
    {
        if (strcmp(e->code, "KeyW") == 0)
        {
            if (eventType == 2) pressedButtons[0] = 1;
            else pressedButtons[0] = 0;
        }
        else if (strcmp(e->code, "KeyS") == 0)
        {
            if (eventType == 2) pressedButtons[1] = 1;
            else pressedButtons[1] = 0;
        }

        if (strcmp(e->code, "KeyA") == 0)
        {
            if (eventType == 2) pressedButtons[2] = 1;
            else pressedButtons[2] = 0;
        }
        else if (strcmp(e->code, "KeyD") == 0)
        {
            if (eventType == 2) pressedButtons[3] = 1;
            else pressedButtons[3] = 0;
        }
    }

    void handleMouse(int eventType, const EmscriptenMouseEvent *mouseEvent, void *userData) {}
    void update(Container<Object>* objectContainer,int elapsedTime)
    {

        if(pressedButtons[0] == 1) speedY = -player->getSpeed();
        if(pressedButtons[1] == 1) speedY = player->getSpeed();
        if(pressedButtons[2] == 1) speedX = -player->getSpeed();
        if(pressedButtons[3] == 1) speedX = player->getSpeed();

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
};

#endif