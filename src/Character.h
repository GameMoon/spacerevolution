#ifndef CHARACTER_H
#define CHARACTER_H

#include "Object.h"
#include "Sprite.h"
#include "Screen.h"

class Character : public Object
{
  private:
    Sprite *sprite;
    int speed;

  public:
    Character(Vector2 *pos, Sprite *sprite)
    {
        this->pos = pos;
        this->sprite = sprite;
        this->width = this->sprite->getFrameWidth();
        this->height = this->sprite->getFrameHeight();
        speed = 1;
    }
    ~Character(){ delete sprite;}

    void move(int x, int y, int elapsedTime)
    {
        if(x == 0 && y == 0){
            sprite->setCurrentFrame(0); //standing animation
            sprite->setCurrentMovement(8); //standing animation
        }
        else{
            this->pos->setX(x+pos->getX());
            this->pos->setY(y+pos->getY());
            
            if(x > 0 && y > 0) sprite->setCurrentMovement(5);
            else if(x < 0 && y < 0) sprite->setCurrentMovement(1);
            else if(x < 0 && y > 0) sprite->setCurrentMovement(2);
            else if(x > 0 && y < 0) sprite->setCurrentMovement(4);
            else if(x == 0 && y > 0)  sprite->setCurrentMovement(6);
            else if(x == 0 && y < 0)  sprite->setCurrentMovement(7);
            else if(x > 0 && y == 0) sprite->setCurrentMovement(3);
            else if(x < 0 && y == 0) sprite->setCurrentMovement(0);

            sprite->updateFrame(elapsedTime);
            this->invalidate();
        }
    }

    void draw(Screen *screen)
    {
        int xOffset = this->pos->getX();
        int yOffset = this->pos->getY();

        sprite->draw(xOffset, yOffset, screen);
    }
    int getSpeed(){
        return speed;
    }
    void setSpeed(int speed){ this->speed = speed;}
};

#endif