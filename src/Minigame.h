#ifndef MINIGAME_H
#define MINIGAME_H
#include "Console.h"

class Minigame
{
private:
    /* data */
public:
    Minigame(/* args */);
    ~Minigame();

    void sendLine(char * inString)
    {
        
    }
    void clearTerm()
    {

    }

    void playGame(int gameid, char * keyboardInput)
    {
        switch (gameid)
        {
            case 1:
                /* code */
                game1(keyboardInput);
                break;
            case 2:
                /* code */

                break;
            case 3:
                /* code */
                break;
            case 4:
                /* code */
                break;
        
            default:
                break;
        }
    }

    void game1(char * keyboardInput)
    {
        sendLine(">Level 1 Terminal, Typing Challenge");
        sendLine(">To do some serious pro hacking,");
        sendLine(">start mashing your keyboard like a madman.");
        sendLine("-------------------------------------------");
        char * prevInput = new char[sizeof(* keyboardInput)];
        prevInput = keyboardInput;
        int bps=0;

        while(true){
            if (keyboardInput != prevInput) {
            clearTerm();
            break;
            }
        }
        prevInput = keyboardInput;
        while(true){
            if (keyboardInput != prevInput) {
                prevInput = keyboardInput;
                int pressedButtonsCount = sizeof(prevInput) / sizeof(prevInput[0]);
                bps+=pressedButtonsCount;
            }
            
            clearTerm();
            sendLine("Buttonpresses/second: " + bps);
            if (elapsedTime >1000) {
                elapsedTime=0;
                bps=0;
            }
            

            if (bps>40) {
                break;
            }
        }

    }
    void game2()
    {
        
    }
    void game3()
    {
        
    }
    void game4()
    {
        
    }





};

Minigame::Minigame(/* args */)
{
}

Minigame::~Minigame()
{
}



#endif