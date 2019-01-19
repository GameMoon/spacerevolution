#ifndef GAME_H
#define GAME_H

#include <sys/time.h>
#include <math.h>
#include <stdint.h>
#include <string.h>

#include <emscripten/html5.h>

#include "Screen.h"
#include "Player.h"
#include "PlayerController.h"
#include "TileController.h"
#include "Container.h"
#include "Terminal.h"
#include "Map.h"

#define WIDTH 1920
#define HEIGHT 1080

class Game
{
  private:
    Screen *screen;
    Image *images;
    int imagesToLoad;
    int numberOfImages;

    PlayerController * playerController;
    Player *p;
    Container<Object> objects;
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
        lastTime = 0;
        gameState = 0;
        
        numberOfImages = 0;
        imagesToLoad = 2;
        images = new Image[imagesToLoad];
        printf("Loading ... \n");
    }
    ~Game(){
        delete screen;
    }

    Screen* getScreen(){ return screen;}
    PlayerController* getPlayerController(){ return playerController;}
    Container<Object>& getObjects();


    void loadImage(int pointerValue, int width, int height)
    {
        uint8_t *pointer = ((uint8_t *)(intptr_t)(pointerValue));
        images[numberOfImages].setPixels(pointer);
        images[numberOfImages].setSize(width, height);
        numberOfImages++;
    }

    void update()
    {
        if (gameState == 0)
        {
            if (numberOfImages == imagesToLoad) gameState++;
            return;
        }
        else if (gameState == 1)
        {
            //Loading Objects
            printf("Images loaded: %d\n",numberOfImages);
            p = new Player(new Vector2(62, 184),
                           new Sprite(
                               images[0].getPixels(),
                               images[0].getWidth(),
                               images[0].getHeight(),
                               4,
                               10));
            p->setSpeed(2);
            playerController = new PlayerController(p);

            tileController = new TileController(&images[1]);

            currentMap = new Map(tileController,"maps.txt",0);
           /* objects.add(new Terminal(new Vector2(600,600)));
            objects.at(0)->setImage(tileController->getTile(10));*/
            objects.add(p);
            printf("Loading finished\n");
            gameState = 2;
           
        }
        else if (gameState == 2)
        {
            //Calculate elapsed time
            int currentTime = getTime();
            int elapsedTime = currentTime - lastTime;
            lastTime = currentTime;
            
            //Player update
            playerController->update(objects,elapsedTime);

            //Render
            screen->clearArea1(); 
            currentMap->draw(screen);
           /* for (int k = 0; k < 16; k++)
            {
                tileController->getTile(k)->draw(100 + k * 48, 300, screen);
            }*/
            
            // screen->clearArea2();
            for(int k = 0; k<objects.getSize();k++){
                objects.at(k)->draw(screen);
            }
           
        }
    } 
};


#endif