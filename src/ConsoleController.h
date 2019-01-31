#ifndef CONSOLECONTROLLER_H
#define CONSOLECONTROLLER_H

#include "Console.h"
#include "PlayerController.h"
#include "Container.h"
#include "Terminal.h"
#include "MiniGame.h"


class ConsoleController
{
    Console* console;
    PlayerController * pController;
    Container<Object> * objects;
    MiniGame * miniGame;
    int timeLeft;

    public:
    ConsoleController(Console* console,PlayerController* playerController, Container<Object>* objects): console(console), pController(playerController), objects(objects){
        miniGame = new MiniGame(console, pController->getPressedKeys());
        timeLeft = 0;
    }

    void update(int elapsedTime){
        //Activation
        if( pController->getPressedKeys()[101]== 1){
            Container<Object> * collidedObjects = pController->getCollidedObjects(objects);

            for (int k = 0; k < collidedObjects->getSize(); k++)
            {
                if (collidedObjects->at(k)->getID() == 4)
                {
                    Terminal *terminal = (Terminal *) collidedObjects->at(k);

                    if(terminal->isActive()){
                        terminal->deactivate();

                        pController->setConsoleMode(true);
                        miniGame->start(terminal);
                        timeLeft = 3000;
                    }
                }
            }
            delete collidedObjects;
        }

        if (pController->getPressedKeys()[66] == 1)
        {
            miniGame->reset();
            console->showDefaultText();
            pController->setConsoleMode(false);
        }

        if(miniGame->isActive()) miniGame->update(elapsedTime);
        else if(miniGame->isFinished()) pController->setConsoleMode(false);

        if(timeLeft > 0 && miniGame->isFinished()) timeLeft -= elapsedTime;
        else if(miniGame->isFinished()){
            miniGame->reset();
            console->showDefaultText();
        }

        console->updateFrame(elapsedTime);
    } 
};

#endif