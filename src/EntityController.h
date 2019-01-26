#ifndef ENTITYCONTORLLER_H
#define ENTITYCONTORLLER_H

#include "Vector2.h"

#include "Player.h"
#include "WallHitbox.h"
#include "Terminal.h"

class EntityController
{
    Image *images;

  public:
    EntityController(Image *images) : images(images) {}
    Object *createObject(int id, Vector2 *pos, int width = 0, int height = 0, Image *img = nullptr, Sprite *sprite = nullptr)
    {
        switch (id)
        {
            case 1: return new WallHitbox(pos, width, height);
            case 2: return new Terminal(pos);
            default: return nullptr;
        }  
    }   
    Player *createPlayer(Vector2 *pos)
    {
        Player *p = new Player(pos, new Sprite(
                                   images[0].getPixels(),
                                   images[0].getWidth(),
                                   images[0].getHeight(),
                                   4,
                                   10));
        
        p->setSpeed(2);
        return p;
    }
};

#endif