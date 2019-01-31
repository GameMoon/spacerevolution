#ifndef MAP_H
#define MAP_H

#include "TileController.h"
#include "PlayerController.h"
#include "EntityController.h"
#include "Screen.h"
#include "Image.h"
#include "Player.h"


class Map{
    TileController * tileController;
    EntityController *entityController;
    PlayerController * playerController;

    int * groundTiles;
    int numberOfTiles;
    int numberOfTilesInRow;
    Image* fullMap;
    Container<Object> * objects;
    Player * player;
    TrapDoor * trapDoor;

    Container<NPC> npcs;
    Terminal * lastTerminal;
    char * file;
    Console * console;

    Container<char> mapLines;

    bool initState;

    int level;
    int mapSizeY;

    void generateBackgroundImage(){
        printf("generate backgroundimage\n");
        uint8_t *backgroundImage = new uint8_t[SCREEN1_WIDTH * SCREEN1_HEIGHT * 4];
        for (int k = 0; k < numberOfTiles; k++)
        {
            int xOffset = k % numberOfTilesInRow * TILE_SIZE;
            int yOffset = k / numberOfTilesInRow * TILE_SIZE;
            Image* tile = this->tileController->getTile(groundTiles[k]);
            for(int x = 0; x < tile->getWidth(); x++){
                for(int y = 0; y < tile->getHeight(); y++){
                    int offset = (x + xOffset + (y + yOffset) * SCREEN1_WIDTH) * 4;
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
      
        fullMap = new Image(backgroundImage, SCREEN1_WIDTH, SCREEN1_HEIGHT);
    }
    void clear(){
        objects->erase();
        npcs.erase();
        delete fullMap;
        delete groundTiles;
        groundTiles = new int[numberOfTiles];
    }

    public:
        Map(TileController * tileController,EntityController * entityController, char* file) : 
        tileController(tileController), entityController(entityController) {
            numberOfTilesInRow = 32;
            numberOfTiles = 32*24;
            groundTiles = new int[numberOfTiles];
            objects = new Container<Object>();
            this->file = file;
            level = 0;
            
            mapSizeY = 24;
            char *line = strtok(file, "\n");
            while (line)
            {
                mapLines.add(line);
                line = strtok(NULL, "\n");
            }
        }

        void setupPlayerController(PlayerController * playerController){
            this->playerController = playerController;
        }
        void setupConsole(Console* console){
            this->console = console;
        }

        void loadLevel(int level){
            initState = true;
            this->level = level;

            //Map cleanup before new level
            if(objects->getSize() > 0){
                clear();
                printf("Cleaned up\n");
            }
           
            printf("Numberof map: %d\n",mapLines.getSize());

            for(int k = 0; k< mapLines.getSize(); k++){
                char* tileprefix = strtok(mapLines.at(k)," ");
                char* mapLevelStr = strtok(NULL," ");
                char* levelName = strtok(NULL,"\n");
                
                int mapLevel = atoi(mapLevelStr);
                if (mapLevel == level)
                {
                    printf("Loaded level: %d\n", mapLevel);
                    this->console->clear();
                    this->console->addText(levelName);
                    this->console->setDefaultText(levelName);

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
                   generateBackgroundImage();

                   int entityOffset = k+ mapSizeY+1;
                   for( int l = entityOffset; mapLines.at(l)[0] != '-'; l++)
                   {
                       int startPoint = (int) mapLines.at(l);
                       int textStart = (int) strrchr( mapLines.at(l),';');
                       int length = strlen(mapLines.at(l));

                       char *entityText = new char[length - (textStart - startPoint)];
                       int entityID;
                       int cellX;
                       int cellY;

                       sscanf(mapLines.at(l), "%d;%d;%d;%[^\t\n]\n", &entityID, &cellX, &cellY, entityText);

                       cellX -= 1;
                       cellY -= 1;
                       Object *newObject = nullptr;
                       
                       if (entityID == 0)
                       {
                           player = entityController->createPlayer(new Vector2(cellX * TILE_SIZE, (cellY)*TILE_SIZE));
                           this->playerController->setPlayer(player);
                           newObject = player;
                       }
                       else if(entityID == 3){
                           NPC * npc = entityController->createNPC(new Vector2(cellX * TILE_SIZE, (cellY)*TILE_SIZE));
                           npcs.add(npc);
                           newObject = npc;
                       }
                       else{
                           newObject = entityController->createObject(
                               entityID,
                               new Vector2(cellX * TILE_SIZE, cellY * TILE_SIZE),
                               TILE_SIZE,
                               TILE_SIZE);

                            //Terminálok és ajtók összerendelése
                            if(entityID == 8){
                               lastTerminal->addDoor((Door*) newObject);
                            }
                            if(entityID >= 4 && entityID <=6) lastTerminal = (Terminal*) newObject;

                            //Trapdoor pálya beállítás
                           if(entityID == 7){
                                trapDoor = (TrapDoor*) newObject;
                            }
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
            if(initState){
                this->getBackground()->draw(0, 0, screen);
                initState = false;
            }

            for(int i = 0;i < objects->getSize(); i++){
                Object *currentObject = objects->at(i);
                if(!currentObject->isValid()){
                    //clearscreen
                    fullMap->draw(0, 0, screen,
                                  currentObject->getPosition()->getX()-3,
                                  currentObject->getPosition()->getY()-3,
                                  currentObject->getPosition()->getX() + currentObject->getWidth()+3,
                                  currentObject->getPosition()->getY() + currentObject->getHeight()+3);
                    //Redraw collided entitys
                    Container<Object> * collidedEntities = currentObject->getColliding(-1,-1,objects->getAll(),objects->getSize());
                    for (int k = 0; k < collidedEntities->getSize(); k++)
                    {
                        collidedEntities->at(k)->draw(screen);
                    }
                    delete collidedEntities;
                    currentObject->validate();
                }
                currentObject->draw(screen);
            }
        }
        void update(int elapsedTime){
            for(int k = 0; k < npcs.getSize();k++){
                npcs.at(k)->update(elapsedTime,objects);
            }

            if(trapDoor->isActive()){
                trapDoor->deactivate();
                printf("next level - %d\n",this->level+1);
                loadLevel(this->level+1);
            }
        }
        Player * getPlayer(){ return this->player;}
        Image * getBackground(){ return fullMap;}
        Container<Object>* getObjects(){ return this->objects;}
};

#endif