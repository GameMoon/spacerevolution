#ifndef TERMINAL_H
#define TERMINAL_H

#include "Object.h"
#include "Vector2.h"
#include "Door.h"

class Terminal : public Object
{
  bool activated;
  Container<Door> doors;
  int bps;

  public:
    Terminal(Vector2 *pos,Image* img,int bps) {
        this->img = img;
        this->pos = pos;
        this->width = TILE_SIZE;
        this->height = TILE_SIZE;
        this->id = 4;
        this->bps = bps;
        activated = false;
    }

    void addDoor(Door * door){
        doors.add(door);
    }
    
    void openDoors(){
        for(int k = 0; k< doors.getSize();k++) doors.at(k)->open();
    }

    void activate(Object* source){
        if(!activated && source->getID() == 0){
            activated = true;
        }
    }
    
    void draw(Screen *screen) {
        img->draw(this->pos->getX(),this->pos->getY(),screen);
    }
    void deactivate(){ activated = false;}
    bool isActive(){ return activated;}
    int getBPS(){ return bps;}
};


#endif