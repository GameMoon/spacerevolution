#ifndef TERMINAL_H
#define TERMINAL_H

#include "Object.h"
#include "Vector2.h"

class Terminal : public Object
{
   bool activated;
  public:
    Terminal(Vector2 *pos) {
        this->pos = pos;
        this->width = TILE_SIZE;
        this->height = TILE_SIZE;
        this->id = 2;

        activated = false;
    }

    void activate(Object* source){
        if(!activated){
            activated = true;
            printf("Terminal activated\n");
        }
       
    }
    
    void draw(Screen *screen) {
        // for (int x = 0; x < width; x += 1)
        // {
        //     for (int y = 0; y < height; y += 1)
        //     {
        //         screen->draw(
        //             x + this->pos->getX(),
        //             y + this->pos->getY(),
        //             255,
        //             0,
        //             0,
        //             255);
        //     }
        // }
    }
};


#endif