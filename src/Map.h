#ifndef MAP_H
#define MAP_H

#include "TileController.h"
#include "Screen.h"

class Map{
    TileController * tileController;

    int * groundTiles;
    int numberOfTiles;
    int numberOfTilesInRow;

    public:
        Map(TileController * tileController,const char* file,int level) : tileController(tileController){
            numberOfTilesInRow = 21;
            numberOfTiles = 10;
            groundTiles = new int[numberOfTiles];

            for (int k = 0; k < numberOfTiles; k++)
            {
                groundTiles[k] = k;
            }
        }

        /*void loadLevel(const char* file, int level){

            for()
        }*/

        void draw(Screen * screen){
            for (int k = 0; k < numberOfTiles; k++)
            {
                int x = k % numberOfTilesInRow * TILE_SIZE;
                int y = k / numberOfTilesInRow * TILE_SIZE;
                this->tileController->getTile(groundTiles[k])->draw(x,y,screen);
            }
        }
};

#endif