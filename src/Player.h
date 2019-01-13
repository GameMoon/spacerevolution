#ifndef PLAYER_H
#define PLAYER_H

#include "Object.h"

class Player : Object{
    public:
        Player(Vector2 * pos, Image * img){ this->pos = pos; this->img = img;}
        void move(int x, int y){ pos->setX(x ); pos->setY(y);}
        void draw(Screen *screen)
        {
            int xOffset = this->pos->getX();
            int yOffset = this->pos->getY();

            for(int x = 1; x < 40;x+=1){
                for(int y = 1; y < 29; y+=1){
                   
                        int imageOffset = (x + y * img->getWidth()) * 4;
                        if (img->getPixel(imageOffset + 3) != 0)
                        {
                            screen->draw(
                                x + xOffset,
                                y + yOffset,
                                img->getPixel(imageOffset),
                                img->getPixel(imageOffset + 1),
                                img->getPixel(imageOffset + 2),
                                img->getPixel(imageOffset + 3));
                        }
                }
            }
        }
};

#endif