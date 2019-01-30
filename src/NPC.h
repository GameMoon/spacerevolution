#ifndef NPC_H
#define NPC_H

#include "Character.h"
#include <time.h>

class NPC : public Character
{
    int speedX;
    int speedY;
    int timeToWait;

    void updateSpeed()
    {
        speedX = rand() % 3 - 1;
        speedY = rand() % 3 - 1;
        timeToWait = rand() % 3000;
    }

  public:
    NPC(Vector2 *pos, Sprite *sprite) : Character(pos, sprite)
    {
        this->id = 3;
        speedX = speedY = 1;
        srand(time(NULL));
        timeToWait = 0;
    }
    void update(int elapsedTime,Container<Object>* objectContainer){
        if (!this->isBlocked(
                this->getPosition()->getX() + speedX,
                this->getPosition()->getY() + speedY,
                objectContainer->getAll(),
                objectContainer->getSize()))
        {
            this->move(speedX, speedY, elapsedTime);
            timeToWait-=elapsedTime;
            if(timeToWait <= 0) updateSpeed();
        }
        else{
            updateSpeed();
            this->move(0, 0, elapsedTime);
        }
    }
   
    bool isBlocking(Object * source)
    {
        if(source->getID() == 3)  return true;
        else return false;
    }
};

#endif