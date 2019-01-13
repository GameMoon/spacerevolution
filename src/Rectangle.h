#ifndef RECTANGLE_H
#define RECTANGLE_H

#include "Object.h"
#include "Vector2.h"

class Rectangle : public Object
{
    int width;
    int height;
    public: 
        Rectangle(Vector2 * pos, int width, int height) : width(width), height(height){
            this->pos = pos;
        }
        void draw(Screen *screen) { printf("Draw rectangle\n"); }
};

#endif