#ifndef CONSOLECONTROLLER_H
#define CONSOLECONTROLLER_H

#include "Console.h"
#include "PlayerController.h"
#include "Container.h"
#include "Terminal.h"

class ConsoleController
{
    Console* console;
    PlayerController * pController;
    Container<Object> * objects;

    public:
    ConsoleController(Console* console,PlayerController* playerController, Container<Object>* objects): console(console), pController(playerController), objects(objects){

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
                        // console->clear();
                        // console->addText("This is a minigame");
                        terminal->openDoors();
                        pController->setConsoleMode(true);
                        terminal->deactivate();
                    }
                }
            }
            delete collidedObjects;
        }

        console->updateFrame(elapsedTime);
    } 
};

#endif