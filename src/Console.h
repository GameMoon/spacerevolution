#ifndef CONSOLE_H
#define CONSOLE_H

#include "Image.h"
#include "Screen.h"
#include "TextGenerator.h"

class Console
{
  Image * fontSprite;
  TextGenerator * text;
  Container<Image> * characterImages;

  public:
    Console(Image * image) : fontSprite(image) {
        text = new TextGenerator(image);

        characterImages = text->create("_`{}[]\~|");
    }


    void draw(Screen * screen){
        screen->clearArea2();

        for (int k = 0; k < characterImages->getSize();k++){
            characterImages->at(k)->drawConsole(k*32+20,20,screen);
        }
    }
};

#endif