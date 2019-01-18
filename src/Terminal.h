#ifndef TERMINAL_H
#define TERMINAL_H

#include "Object.h"
#include "Vector2.h"

class Terminal : public Object
{
   
  public:
    Terminal(Vector2 *pos) {
        this->pos = pos;
        this->width = 48;
        this->height = 48;
        this->id = 6;
    }
    
    void draw(Screen *screen) {
        int xPos = this->pos->getX();
        int yPos = this->pos->getY();

        for (int x = 0; x < this->width; x += 1)
        {
            for (int y = 0; y < this->height; y += 1)
            {
                screen->draw(
                    x + xPos,
                    y + yPos,
                    255,
                    0,
                    255,
                    255);
            }
        }
    }
};


#endif