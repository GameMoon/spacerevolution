#ifndef GAME_H
#define GAME_H

#include <sys/time.h>
#include <math.h>
#include <stdint.h>
#include <string.h>
#include <stdlib.h>

#include <emscripten/html5.h>

#include "Screen.h"
#include "PlayerController.h"
#include "TileController.h"
#include "ConsoleController.h"
#include "Container.h"
#include "Map.h"
#include "Console.h"

#define WIDTH 1920
#define HEIGHT 1080

#define IMAGES_TO_LOAD 5
#define OTHER_FILES_TO_LOAD 1

class Game
{
  private:
    Screen *screen;
    Image *images;
    char * mapContent;
    int imagesToLoad;
    int numberOfImages;
    int filesToLoad;
    int loadedFiles;

    PlayerController * playerController;
    EntityController * entityController;
    ConsoleController * consoleController;
    Console * console;
    Player *p;
    TileController *tileController;

    struct timeval currentTimeVal;
    int lastTime;

    int gameState;
    Map * currentMap;

    long int getTime()
    {
        gettimeofday(&currentTimeVal, NULL);
        return currentTimeVal.tv_sec * 1000 + currentTimeVal.tv_usec / 1000;
    }

  public:
    Game()
    {
        screen = new Screen(WIDTH, HEIGHT);
        lastTime = getTime();
        gameState = 0;
        
        numberOfImages = 0;
        imagesToLoad = IMAGES_TO_LOAD;
        images = new Image[imagesToLoad];

        filesToLoad = imagesToLoad + OTHER_FILES_TO_LOAD; //images + map
        loadedFiles = 0;
        printf("Loading ... \n");
    }
    ~Game(){
        delete screen;
    }

    Screen* getScreen(){ return screen;}
    PlayerController* getPlayerController(){ return playerController;}
    Container<Object>& getObjects();

    Image* getImage(int index){
        for(int k = 0; k< numberOfImages; k++){
            if(images[k].getID() == index ) return &images[k];
        }
        return nullptr;
    }

    void loadImage(int pointerValue, int width, int height, int id)
    {
        uint8_t *pointer = ((uint8_t *)(intptr_t)(pointerValue));
        images[numberOfImages].setPixels(pointer);
        images[numberOfImages].setSize(width, height);
        images[numberOfImages].setID(id);
        numberOfImages++;
        loadedFiles++;
    }
    void loadMap(int pointerValue)
    {
        char *pointer = ((char *)(intptr_t)(pointerValue));
        mapContent = pointer;
        loadedFiles++;
    }

    void update()
    {
        if (gameState == 0)
        {
            if (loadedFiles == filesToLoad) gameState++;
            return;
        }
        else if (gameState == 1)
        {
            //Loading Objects
            tileController = new TileController(getImage(1));
            entityController = new EntityController(images,numberOfImages,tileController);
            currentMap = new Map(tileController,entityController,mapContent);

            console = new Console(getImage(2));
            currentMap->setupConsole(console);


            playerController = new PlayerController();
            currentMap->setupPlayerController(playerController);

            currentMap->loadLevel(1);

            consoleController = new ConsoleController(console,playerController,currentMap->getObjects());
                        
            //Drawing full background
            getImage(4)->draw(0,0,screen,0,0,-1,-1,-1);

            printf("Loaded\n");
            gameState = 2;
           
        }
        else if (gameState == 2)
        {
            //Calculate elapsed time
            int currentTime = getTime();
            int elapsedTime = currentTime - lastTime;
            lastTime = currentTime;

            //Player update
            playerController->update(currentMap->getObjects(),elapsedTime);
            consoleController->update(elapsedTime);
            currentMap->update(elapsedTime);

            //Render
            currentMap->draw(screen);
            console->draw(screen);
        }
    } 
};


#endif