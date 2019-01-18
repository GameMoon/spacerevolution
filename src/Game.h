#ifndef GAME_H
#define GAME_H

#include <vector>
#include <sys/time.h>
#include <math.h>
#include <stdint.h>
#include <string.h>

#include <emscripten/html5.h>
#include <iostream>
#include "Screen.h"
#include "Player.h"
#include "PlayerController.h"

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
    std::vector<std::string> imagePath;

    struct timeval currentTimeVal;
    int lastTime;

    int gameState;

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
        imagesToLoad = 1;
        images = new Image[imagesToLoad];
        printf("Loading ... \n");
    }

    Screen* getScreen(){ return screen;}
    PlayerController* getPlayerController(){ return playerController;}

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
            printf("Images loaded\n");
            p = new Player(new Vector2(62, 184),
                           new Sprite(
                               images[0].getPixels(),
                               images[0].getWidth(),
                               images[0].getHeight(),
                               4,
                               1));
            p->setSpeed(2);
            playerController = new PlayerController(p);
            gameState = 2;
        }
        else if (gameState == 2)
        {
            //Calculate elapsed time
            int currentTime = getTime();
            int elapsedTime = currentTime - lastTime;
            lastTime = currentTime;
            
            //Player update
            playerController->update(elapsedTime);

            //Render
            screen->clearArea1();
            // screen->clearArea2();
            p->draw(screen);
        }
    }

   
};

#endif