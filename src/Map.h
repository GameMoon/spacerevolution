#ifndef MAP_H
#define MAP_H

#include "TileController.h"
#include "EntityController.h"
#include "Screen.h"
#include "Image.h"
#include "Player.h"

#define SCREEN1_W 1024
#define SCREEN1_H 768

class Map{
    TileController * tileController;
    EntityController *entityController;

    int * groundTiles;
    int numberOfTiles;
    int numberOfTilesInRow;
    Image* fullMap;
    Container<Object> * objects;
    Player * player;

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
        Map(TileController * tileController,EntityController * entityController,char* file,int level) : tileController(tileController), entityController(entityController){
            numberOfTilesInRow = 32;
            numberOfTiles = 32*24;
            groundTiles = new int[numberOfTiles];
            objects = new Container<Object>();

            loadLevel(file,level);

            generateBackgroundImage();
        }


        void loadLevel(char* data, int level){

            Container<char> mapLines;
            int mapSizeY = 24;

            char * line = strtok(data, "\n");
            while(line){
                mapLines.add(line);
                line = strtok(NULL, "\n");
            }
            
            for(int k = 0; k< mapLines.getSize(); k++){
                int mapLevel;
                char levelName[30];
                sscanf(mapLines.at(k), "Mission %d %s", &mapLevel, levelName);
                if (mapLevel == level)
                {
                    printf("Mission %d %s\n", mapLevel, levelName);
                    int tileIndex = 0;
                    for (int l = k + 1; l < k + mapSizeY+1; l++)
                    {
                        char *tileId = strtok(mapLines.at(l), ";");
                        while (tileId)
                        {
                            groundTiles[tileIndex] = atoi(tileId);
                            tileIndex++;
                            tileId = strtok(NULL, ";");
                        }
                   }

                   int entityOffset = mapSizeY+1;
                   for( int l = entityOffset; mapLines.at(l)[0] != '-'; l++)
                   {
                       char * entityText = new char[255];
                       int entityID;
                       int cellX;
                       int cellY;
                       sscanf(mapLines.at(l), "%d;%d;%d;%[^\t\n]\n", &entityID, &cellX, &cellY, entityText);

                       cellX -= 1;
                       cellY -= 1;
                       Object *newObject = nullptr;
                       
                       if (entityID == 0)
                       {
                           player = entityController->createPlayer(new Vector2(cellX * 32, (cellY) * 32));
                           newObject = player;
                       }
                       else{
                           newObject = entityController->createObject(
                               entityID,
                               new Vector2(cellX * TILE_SIZE, cellY * TILE_SIZE),
                               TILE_SIZE,
                               TILE_SIZE);
                       }
                       
                       if(newObject != nullptr){
                           newObject->setText(entityText);
                           this->objects->add(newObject);
                       }
                   }
                   return;
                }
            }
        }

        void draw(Screen * screen){
      
            for(int i = 0;i < objects->getSize(); i++){
                Object *currentObject = objects->at(i);
                if(!currentObject->isValid()){
                    fullMap->draw(0, 0, screen,
                                  currentObject->getPosition()->getX()-10,
                                  currentObject->getPosition()->getY()-10,
                                  currentObject->getPosition()->getX() + currentObject->getWidth()+10,
                                  currentObject->getPosition()->getY() + currentObject->getHeight()+10);
                    //clearscreen
                    currentObject->validate();
                }
                currentObject->draw(screen);
            }
        }
        Player * getPlayer(){ return this->player;}
        Image * getBackground(){ return fullMap;}
        Container<Object>* getObjects(){ return this->objects;}
};

#endif