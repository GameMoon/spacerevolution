#ifndef PLAYER_H
#define PLAYER_H

#include "Object.h"
#include "Sprite.h"

class Player : Object{
    private:
        Sprite * sprite;
    public:
        Player(Vector2 * pos, Sprite * sprite){ this->pos = pos; this->sprite = sprite;}
        void move(int x, int y, int elapsedTime){ 
            if(pos->getX() != x || pos->getY() != y)
            {
                sprite->updateFrame(elapsedTime,9);
            } 
            pos->setX(x);
            pos->setY(y);
        }
        void draw(Screen *screen)
        {
            int xOffset = this->pos->getX();
            int yOffset = this->pos->getY();

            sprite->draw(xOffset, yOffset, 8, screen);
        }
};

#endif