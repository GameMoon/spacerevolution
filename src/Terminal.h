#ifndef TERMINAL_H
#define TERMINAL_H

#include "Object.h"
#include "Vector2.h"

class Terminal : public Object
{
  bool activated;
  
  public:
    Terminal(Vector2 *pos,Image* img) {
        this->img = img;
        this->pos = pos;
        this->width = TILE_SIZE;
        this->height = TILE_SIZE;
        this->id = 4;

        activated = false;
    }

    void activate(Object* source){
        if(!activated && source->getID() == 0){
            activated = true;
            printf("Terminal activated\n");
        }
    }
    
    void draw(Screen *screen) {
        img->draw(this->pos->getX(),this->pos->getY(),screen);
    }
    void deactivate(){ activated = false;}
    bool isActive(){ return activated;}
};


#endif