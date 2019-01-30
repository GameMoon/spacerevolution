#ifndef OBJECT_H
#define OBJECT_H

#include "Vector2.h"
#include "Image.h"
#include "Screen.h"
#include "Container.h"

class Object
{
  protected:
    Vector2 *pos;
    Image * img;
    int width;
    int height;
    int id;
    bool valid;
    char * text;
    Vector2 * hitboxPos;
    int hitBoxWidth;
    int hitBoxHeight;

  public:
    Object(){
      hitBoxWidth = hitBoxHeight = -1;
      hitboxPos = nullptr;
    }
    virtual ~Object(){
      delete text;
    }
    void setHitbox(Vector2 * pos, int width, int height){
        hitBoxHeight = height;
        hitBoxWidth = width;
        hitboxPos = pos;
    }

    void setPosition(Vector2 * pos) {this->pos = pos; }
    Vector2* getPosition() { return this->pos; }
    Vector2 *getHitBoxPos() { return hitboxPos; }
    virtual void draw(Screen *screen) = 0;
    int getWidth(){return width;}
    int getHeight(){return height;}
    int getID(){return id;}
    void setImage(Image* img){ this->img = img;}
    void setText(char * text){ this->text = text;}
    char* getText(){ return this->text;}

    bool isBlocked(int newPosX = -1, int newPosY = -1, Object** objects = nullptr, int size = 0){
        
        if(hitboxPos != nullptr && newPosX == -1 && newPosY == -1){
          newPosX = hitboxPos->getX();
          newPosY = hitboxPos->getY();
        }
        
        if(newPosX == -1) newPosX = this->pos->getX();
        if(newPosY == -1) newPosY = this->pos->getY();
        int hitHeight = height;
        int hitWidth = width;

        if(hitBoxHeight != -1) hitHeight = hitBoxHeight;
        if(hitBoxWidth != -1) hitWidth = hitBoxWidth;


        for(int k = 0; k < size; k++){
          if (objects[k] == this) continue;
          Vector2 * oPos = objects[k]->getPosition();
          Object *object = objects[k];

          if (newPosX < oPos->getX() + object->getWidth() && newPosX + hitWidth > oPos->getX() &&
              newPosY < oPos->getY() + object->getHeight() && newPosY + hitHeight > oPos->getY())
          { 
            object->activate(this);
            if(object->isBlocking(this)) return true;
          }
        }
        return false;
    }
    
    Container<Object> getColliding(int newPosX = -1, int newPosY = -1, Object** objects = nullptr, int size = 0){
        if(hitboxPos != nullptr && newPosX == -1 && newPosY == -1){
          newPosX = hitboxPos->getX();
          newPosY = hitboxPos->getY();
        }

        if(newPosX == -1) newPosX = this->pos->getX();
        if(newPosY == -1) newPosY = this->pos->getY();
        int hitHeight = height;
        int hitWidth = width;

        if (hitboxPos != nullptr)
        {
          newPosX = hitboxPos->getX();
          newPosY = hitboxPos->getY();
        }

        if(hitBoxHeight != -1) hitHeight = hitBoxHeight;
        if(hitBoxWidth != -1) hitWidth = hitBoxWidth;

        Container<Object> collidedEntities;

        for(int k = 0; k < size; k++){
          if (objects[k] == this) continue;
          Vector2 * oPos = objects[k]->getPosition();
          Object *object = objects[k];

          if (newPosX < oPos->getX() + object->getWidth() && newPosX + hitWidth > oPos->getX() &&
              newPosY < oPos->getY() + object->getHeight() && newPosY + hitHeight > oPos->getY())
          {
            collidedEntities.add(object);
          }
        }

        return collidedEntities;
    }
    bool isValid() { return valid; }
    void validate() { valid = true; }
    void invalidate() { valid = false; }
    virtual bool isBlocking(Object * source) { return false; }
    virtual void activate(Object * source){   /*printf("%s\n", this->getText());*/ }
};

#endif