#ifndef MINIGAME_H
#define MINIGAME_H

#include <stdio.h>
#include "Console.h"
#include "Terminal.h"


class MiniGame
{
    private:
        Terminal * terminal;
        Console * console;
        int * oldPressedKeys;
        int * pressedKeys;
        int bps;
        int timeLeft;
        char buffer[40];
        bool active;
        bool finished;
        int bpsLimit;
    public:
    MiniGame(Console *console,int * pressedKeys) : console(console), pressedKeys(pressedKeys){
        oldPressedKeys = new int[200]();
        
        bps = timeLeft = bpsLimit = 0;
        active = false;
        finished = false;
    }
    ~MiniGame(){ delete oldPressedKeys;}

    void showMessage(){
        console->clear();
        console->addLine(">Level 1 Terminal, Typing Challenge");
        console->addLine(">To do some serious pro hacking,");
        console->addLine(">start mashing your keyboard like a madman.");
        console->addLine("-------------------------------------------");
        console->addLine("");
    }
    void reset(){
        this->finished = false;
        active = false;
    }

    void start(Terminal * terminal)
    {
        for (int k = 0; k < 200; k++)
        {
            oldPressedKeys[k] = pressedKeys[k];
        }
        bps = timeLeft = 0;
        this->terminal = terminal;
        bpsLimit = this->terminal->getBPS();
        showMessage();
        active = true;
        finished = false;
    }
    
    int numberOfNewlyPressedKeys(){
        int numberOfPressedKeys = 0;
        for(int k =0; k< 200; k++){
            if(pressedKeys[k] == oldPressedKeys[k]) continue;
            numberOfPressedKeys++;
            oldPressedKeys[k] = pressedKeys[k];
        }
        return numberOfPressedKeys;
    }

    void update(int elapsedTime){
        showMessage();
        sprintf(buffer, "Buttonpresses/second: %d", bps);
        console->addLine(buffer);
        if(timeLeft <= 0){
            timeLeft = 1000;
            if(bps >= bpsLimit){
                terminal->openDoors();
                active = false;
                finished = true;
                console->clear();
                console->addLine("");
                console->addLine("Congratulation!");
                console->addLine("");
                console->addLine("You are successfully hacked the door");
            }
            bps = 0;
        }
        else timeLeft -= elapsedTime;
        bps += numberOfNewlyPressedKeys();
    }
    bool isActive(){ return active; }
    bool isFinished(){ return finished; }

};

#endif