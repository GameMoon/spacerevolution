#ifndef TRAPDOOR_H
#define TRAPDOOR_H

#include "Object.h"
#include "Vector2.h"

class TrapDoor : public Object
{
  bool active;
  public:
    TrapDoor(Vector2 *pos)
    {
        this->pos = pos;
        this->width = TILE_SIZE;
        this->height = TILE_SIZE;
        this->id = 7;
        active = false;
    }

    bool isActive(){return active;}

    void deactivate() { active = false; }

    void activate(Object *source){
        if(!active) active = true;
    }

    void draw(Screen *screen)
    {
    }
};

#endif