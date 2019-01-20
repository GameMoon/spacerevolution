#ifndef OBJECT_H
#define OBJECT_H

#include "Vector2.h"
#include "Image.h"
#include "Screen.h"

class Object
{
  protected:
    Vector2 *pos;
    Image * img;
    int width;
    int height;
    int id;
    bool valid;

  public:
    void setPosition(Vector2 * pos) {this->pos = pos; }
    Vector2* getPosition() { return this->pos; }
    virtual void draw(Screen *screen) = 0;
    int getWidth(){return width;}
    int getHeight(){return height;}
    int getID(){return id;}
    void setImage(Image* img){ this->img = img;}
    
     bool isCollide(int newPosX = -1, int newPosY = -1, Object** objects = nullptr, int size = 0){
        if(newPosX == -1) newPosX = this->pos->getX();
        if(newPosY == -1) newPosY = this->pos->getY();

        for(int k = 0; k < size; k++){
          if (objects[k] == this) continue;
          Vector2 * oPos = objects[k]->getPosition();
          Object *object = objects[k];

          if (newPosX < oPos->getX() + object->getWidth() && newPosX + width > oPos->getX() &&
              newPosY < oPos->getY() + object->getHeight() && newPosY + height > oPos->getY()
          )
          { 
            return true;
          }
              // newPosY+height < oPos->getY() + object->getHeight() && newPosY > oPos->getY())
        }
        return false;
    }
    bool isValid() { return valid; }
    void validate() { valid = true; }
    void invalidate() { valid = false; }
};

#endif