#ifndef CHARACTER_H
#define CHARACTER_H

#include "Object.h"
#include "Sprite.h"
#include "Screen.h"

class Character : Object
{
  private:
    Sprite *sprite;
    int speed;

  public:
    Character(Vector2 *pos, Sprite *sprite)
    {
        this->pos = pos;
        this->sprite = sprite;
        speed = 1;
    }
    ~Character(){ delete sprite;}

    void move(int x, int y, int elapsedTime)
    {
        if(x == 0 && y == 0) sprite->setCurrentFrame(2); //standing animation
        else{
            pos->setX(x+pos->getX());
            pos->setY(y+pos->getY());
            sprite->updateFrame(elapsedTime);
        }
    }

    void draw(Screen *screen)
    {
        int xOffset = this->pos->getX();
        int yOffset = this->pos->getY();

        sprite->draw(xOffset, yOffset, 0, screen);
    }
    int getSpeed(){
        return speed;
    }
    void setSpeed(int speed){ this->speed = speed;}
};

#endif