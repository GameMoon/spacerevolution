#ifndef TERMINAL_H
#define TERMINAL_H

#include "Object.h"
#include "Vector2.h"

class Terminal : public Object
{
   
  public:
    Terminal(Vector2 *pos) {
        this->pos = pos;
        this->width = 20;
        this->height = 48;
        this->id = 2;
    }
    
    void draw(Screen *screen) {
        img->draw(pos->getX()-width,pos->getY(),screen);
    }
};


#endif