#ifndef WALLHITBOX_H
#define WALLHITBOX_H

#include "Object.h"
#include "Sprite.h"
#include "Screen.h"

class WallHitbox : public Object
{
    public:
      WallHitbox(Vector2 *pos, int width, int height)
    {
        this->id = 1;
        this->pos = pos;
        this->width = width;
        this->height = height;
    }
    
    bool isBlocking(Object * source){
        return true;
    }
    void draw(Screen * screen){}
};

#endif