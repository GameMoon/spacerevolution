#ifndef VECTOR2_H
#define VECTOR2_H

class Vector2{
    int posX;
    int posY;
    public:
        Vector2(int posX = 0,int posY = 0): posX(posX), posY(posY) {}
        void setX(int posX){ this->posX = posX;}
        void setY(int posY){ this->posY = posY;}
        int getX(){return posX;}
        int getY(){return posY;}
};

#endif