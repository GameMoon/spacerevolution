#ifndef OBJECT_H
#define OBJECT_H

#include "Vector2.h"
#include "Image.h"

class Object
{
  protected:
    Vector2 pos;
    Image img;

  public:
    void setPosition(Vector2 pos) {this->pos = pos; }
    Vector2 getPosition() { return this->pos; }
    virtual void draw() = 0;
};

#endif