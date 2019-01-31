#ifndef ENTITYCONTORLLER_H
#define ENTITYCONTORLLER_H

#include "Vector2.h"

#include "Player.h"
#include "WallHitbox.h"
#include "Terminal.h"
#include "NPC.h"
#include "Door.h"
#include "Terminal.h"
#include "TrapDoor.h"

class EntityController
{
    Image *images;
    TileController * tileController;
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
    EntityController(Image *images,int numberOfImages, TileController * tileController) : images(images) , numberOfImages(numberOfImages), tileController(tileController){}
    Object *createObject(int id, Vector2 *pos, int width = 0, int height = 0, Image *img = nullptr, Sprite *sprite = nullptr)
    {
        switch (id)
        {
            //0 Player
            case 1: return new WallHitbox(pos, width, height);
            //2 Youdie
            //3 NPC
            case 4: return new Terminal(pos,tileController->getTile(649),30);
            case 5: return new Terminal(pos,tileController->getTile(661),50);
            case 6: return new Terminal(pos,tileController->getTile(673),70);

            case 7: return new TrapDoor(pos);
            
            case 8: return new Door(pos,tileController->getTile(625),tileController->getTile(613));
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