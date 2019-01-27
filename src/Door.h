#ifndef DOOR_H
#define DOOR_H

#include "Object.h"
#include "Vector2.h"

class Door : public Object
{
    bool activated;
    Image * openedImg;
    Image * closedImg;
  public:
    Door(Vector2 *pos,Image * open, Image * closed) : openedImg(open), closedImg(closed)
    {
        this->pos = pos;
        this->width = TILE_SIZE;
        this->height = TILE_SIZE;
        this->id = 2;
        activated = false;
    }

    void activate(Object *source)
    {
        if (!activated)
        {
            activated = true;
        }
    }

    void draw(Screen *screen)
    {
       if(activated) openedImg->draw(this->pos->getX(),this->pos->getY(),screen);
       else closedImg->draw(this->pos->getX(),this->pos->getY(),screen);
    }
};

#endif