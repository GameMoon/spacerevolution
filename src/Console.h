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
  int xOffset;
  int yOffset;
  int timeForFrame;

  int outputSize;
public:
    Console(Image *image) : fontSprite(image)
    {
      text = new TextGenerator(image);
      xOffset = yOffset = 20;
      outputSize = 0;
      timeForFrame = -100;

      characterImages = text->create("> Welcome Traveler!");
    }

    void updateFrame(int elapsedTime)
    {
       
        if (timeForFrame < 0 && outputSize < characterImages->getSize())
        {
            outputSize++;
            timeForFrame = 1000 / 12;
        }
        timeForFrame -= elapsedTime;
    }

    void draw(Screen * screen){
        screen->clearArea2();
       
        for (int k = 0; k < outputSize;k++){
            characterImages->at(k)->drawConsole(
                (k % 22) * text->getFontWidth() + xOffset,
                k / 22 * text->getFontWidth() + yOffset,
                screen);
        }
    }
};

#endif