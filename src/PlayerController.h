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
    PlayerController() { speedX = 0; speedY = 0; consoleMode = false; pressedButtons = new int[200];}
    ~PlayerController(){ delete pressedButtons;}

    void setPlayer(Player * p){
        this->player = p;
    }
    void handleKeyboard(int eventType, const EmscriptenKeyboardEvent *e, void *userData)
    {
        char c = e->key[0];
        if (eventType == 2)  pressedButtons[c] = 1;
        else  pressedButtons[c] = 0;
    }
    Container<Object> *getCollidedObjects(Container<Object> *objectContainer)
    {
        return this->player->getColliding(-1,-1,objectContainer->getAll(),objectContainer->getSize());
    }

    void handleMouse(int eventType, const EmscriptenMouseEvent *mouseEvent, void *userData) {}
    void update(Container<Object>* objectContainer,int elapsedTime)
    {
        if(consoleMode) return;

        if(pressedButtons[119] == 1) speedY = -player->getSpeed(); //w
        if(pressedButtons[115] == 1) speedY = player->getSpeed(); //s
        if(pressedButtons[97] == 1) speedX = -player->getSpeed(); //a
        if(pressedButtons[100] == 1) speedX = player->getSpeed(); //d

        // if (speedY == 0 && speedX == 0) return;

        if (!player->isBlocked(
                player->getHitBoxPos()->getX() + speedX,
                player->getHitBoxPos()->getY() + speedY,
                objectContainer->getAll(),
                objectContainer->getSize())){
            player->move(speedX, speedY, elapsedTime);
        }
        else if (!player->isBlocked(
                player->getHitBoxPos()->getX() + speedX,
                player->getHitBoxPos()->getY(),
                objectContainer->getAll(),
                objectContainer->getSize())){
            player->move(speedX, 0, elapsedTime);
        }
        else if (!player->isBlocked(
                player->getHitBoxPos()->getX() ,
                player->getHitBoxPos()->getY() + speedY,
                objectContainer->getAll(),
                objectContainer->getSize())){
            player->move(0, speedY, elapsedTime);
        }
        else  player->move(0, 0, elapsedTime);
        
        if (speedY != 0 || speedX != 0) speedX = speedY = 0;
    }
    int* getPressedKeys(){ return pressedButtons;}
    void setConsoleMode(bool active){ consoleMode = active;}
};

#endif