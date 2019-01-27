#ifndef PLAYER_H
#define PLAYER_H

#include "Character.h"

class Player : public Character{
    public:
        Player(Vector2 * pos, Sprite * sprite) : Character(pos,sprite){ 
            this->id = 0;
        }
        bool isBlocking(Object * source)
        {
            return true;
        }
};

#endif