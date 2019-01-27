#ifndef ENTITYCONTORLLER_H
#define ENTITYCONTORLLER_H

#include "Vector2.h"

#include "Player.h"
#include "WallHitbox.h"
#include "Terminal.h"
#include "NPC.h"

class EntityController
{
    Image *images;
    int numberOfImages;

    Image *getImage(int index)
    {
        for (int k = 0; k < numberOfImages; k++)
        {
            if (images[k].getID() == index)
                return &images[k];
        }
        return nullptr;
    }

  public:
    EntityController(Image *images,int numberOfImages) : images(images) , numberOfImages(numberOfImages){}
    Object *createObject(int id, Vector2 *pos, int width = 0, int height = 0, Image *img = nullptr, Sprite *sprite = nullptr)
    {
        switch (id)
        {
            //0 Player
            case 1: return new WallHitbox(pos, width, height);
            case 2: return new Terminal(pos);
            //3 NPC
            default: return nullptr;
        }  
    }   
    Player *createPlayer(Vector2 *pos)
    {
        Image* pImage = getImage(0);
        Player *p = new Player(pos, new Sprite(
                                   pImage->getPixels(),
                                   pImage->getWidth(),
                                   pImage->getHeight(),
                                   4,
                                   10));
        
        p->setSpeed(2);
        return p;
    }
    NPC *createNPC(Vector2 *pos)
    {
        Image *pImage = getImage(3);
        NPC *p = new NPC(pos, new Sprite(
                                   pImage->getPixels(),
                                   pImage->getWidth(),
                                   pImage->getHeight(),
                                   4,
                                   10));
        
        p->setSpeed(1);
        return p;
    }
    
};

#endif