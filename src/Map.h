#ifndef MAP_H
#define MAP_H

#include "TileController.h"
#include "Screen.h"
#include "Image.h"
#include "Player.h"

#define SCREEN1_W 1024
#define SCREEN1_H 768

class Map{
    TileController * tileController;

    int * groundTiles;
    int numberOfTiles;
    int numberOfTilesInRow;
    Image* fullMap;
    Container<char> mapLines;

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

                    int r = tile->getPixel(tileoffset);
                    int g = tile->getPixel(tileoffset + 1);
                    int b = tile->getPixel(tileoffset + 2);
                    int a = tile->getPixel(tileoffset + 3);
                    if(a != 255) r = g = b = 0;
                    backgroundImage[offset] = r;
                    backgroundImage[offset+1] = g;
                    backgroundImage[offset+2] = b;
                    backgroundImage[offset+3] = 255;
                }
            }
        }
        fullMap = new Image(backgroundImage,SCREEN1_W,SCREEN1_H);
    }

    public:
        Map(TileController * tileController,char* file,int level) : tileController(tileController){
            numberOfTilesInRow = 32;
            numberOfTiles = 32*24;
            groundTiles = new int[numberOfTiles];


            /*for (int k = 0; k < numberOfTiles; k++)
            {
                groundTiles[k] = 12;//rand() % 3468;
            }*/
            loadLevel(file,level);

            generateBackgroundImage();
        }


        void loadLevel(char* data, int level){
           
            char * line = strtok(data, "\n");
            while(line){
                mapLines.add(line);
                line = strtok(NULL, "\n");
            }
            
            for(int k = 0; k< mapLines.getSize(); k++){
                int mapLevel;
                sscanf(mapLines.at(k), "Mission %d", &mapLevel);
                if (mapLevel == level)
                {
                 
                    int tileIndex = 0;
                    for (int l = k + 1; l < k + 25; l++)
                    {
                        char *tileId = strtok(mapLines.at(l), ";");
                        while (tileId)
                        {
                            groundTiles[tileIndex] = atoi(tileId);
                            tileIndex++;
                            tileId = strtok(NULL, ";");
                        }
                   }
                   return;
                }
            }
        }

        void draw(Screen * screen, Container<Object> & container){
      
            for(int i = 0;i < container.getSize(); i++){
                Object * currentObject = container.at(i);
                if(!currentObject->isValid()){
                    fullMap->draw(0, 0, screen,
                                  currentObject->getPosition()->getX()-10,
                                  currentObject->getPosition()->getY()-10,
                                  currentObject->getPosition()->getX() + currentObject->getWidth()+10,
                                  currentObject->getPosition()->getY() + currentObject->getHeight()+10);
                    currentObject->validate();
                }
            }
        }
        Image * getBackground(){ return fullMap;}
};

#endif