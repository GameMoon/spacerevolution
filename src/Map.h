#ifndef MAP_H
#define MAP_H

#include "TileController.h"
#include "Screen.h"
#include "Image.h"

#define SCREEN1_W 1024
#define SCREEN1_H 768

class Map{
    TileController * tileController;

    int * groundTiles;
    int numberOfTiles;
    int numberOfTilesInRow;
    Image* fullMap;

    void generateBackgroundImage(){
        uint8_t *backgroundImage = new uint8_t[SCREEN1_W * SCREEN1_H * 4];
        for (int k = 0; k < numberOfTiles; k++)
        {
            int xOffset = k % numberOfTilesInRow * TILE_SIZE;
            int yOffset = k / numberOfTilesInRow * TILE_SIZE;
            Image* tile = this->tileController->getTile(groundTiles[k]);
            for(int x = 0; x < tile->getWidth(); x++){
                for(int y = 0; y < tile->getHeight(); y++){
                    int offset = (x+xOffset + (y+yOffset) * SCREEN1_W) *4;
                    int tileoffset = (x+y*tile->getWidth())*4;

                    backgroundImage[offset] = tile->getPixel(tileoffset);
                    backgroundImage[offset+1] = tile->getPixel(tileoffset+1);
                    backgroundImage[offset+2] = tile->getPixel(tileoffset+2);
                    backgroundImage[offset+3] = tile->getPixel(tileoffset+3);
                }
            }
        }
        fullMap = new Image(backgroundImage,SCREEN1_W,SCREEN1_H);
    }

    public:
        Map(TileController * tileController,const char* file,int level) : tileController(tileController){
            numberOfTilesInRow = 32;
            numberOfTiles = 32*24;
            groundTiles = new int[numberOfTiles];

            for (int k = 0; k < numberOfTiles; k++)
            {
                groundTiles[k] = k;
            }
            generateBackgroundImage();
        }


        /*void loadLevel(const char* file, int level){

            for()
        }*/

        void draw(Screen * screen){
           /* for (int k = 0; k < numberOfTiles; k++)
            {
                int x = k % numberOfTilesInRow * TILE_SIZE;
                int y = k / numberOfTilesInRow * TILE_SIZE;
                this->tileController->getTile(groundTiles[k])->draw(x,y,screen);
            }*/
            fullMap->draw(0,0,screen);
           
        }
        Image * getBackground(){ return fullMap;}
};

#endif