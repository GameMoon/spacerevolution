#ifndef CONSOLE_H
#define CONSOLE_H

#include "Container.h"
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
  int lastOutputSize;
  int bufferLimit;
  int charLimitInRow;
  int lastBufferSize;

  Container< Container<Image> > buffer;
public:
    Console(Image *image) : fontSprite(image)
    {
      text = new TextGenerator(image);
      xOffset = yOffset = 18;
      outputSize = lastOutputSize = 0;
      timeForFrame = 0;
      bufferLimit = 0;
      lastBufferSize = 0;
      charLimitInRow = 43;
    }

    void updateFrame(int elapsedTime)
    {
        if (timeForFrame < 0 && bufferLimit > 0 && lastOutputSize < buffer.at(buffer.getSize() - 1)->getSize())
        {
            lastOutputSize++;
            timeForFrame = 1000 / 12;
        }
        timeForFrame -= elapsedTime;
    }
    void addText(const char * string, bool isAnimated = false){
        buffer.add(text->create(string));
        if(isAnimated) lastOutputSize = 0;
        else lastOutputSize = buffer.at(buffer.getSize()-1)->getSize();

        int numberOfLines = 0;
        int commands = 0;
        for (int k = buffer.getSize()-1; k >= 0; k--)
        {
            numberOfLines += (buffer.at(k)->getSize() / charLimitInRow) + 1;
            if(numberOfLines <= 28 ) commands++;
        }

        bufferLimit = commands;
    }

    void clear(){
        buffer.clear();
    }

    void draw(Screen * screen){
        if (lastBufferSize == buffer.getSize() && 
        lastOutputSize == buffer.at(buffer.getSize() - 1)->getSize()) return;
        
        screen->clearArea2();

        int lineOffset = 0;
        if(buffer.getSize() == 0) return;

        for (int line = buffer.getSize() - bufferLimit; line < buffer.getSize(); line++)
        {
            if(line != buffer.getSize()-1) outputSize = buffer.at(line)->getSize();
            else outputSize = lastOutputSize;

            for (int k = 0; k < outputSize; k++)
            {
                buffer.at(line)->at(k)->drawConsole(
                    (k % charLimitInRow) * text->getFontWidth() + xOffset,
                    k / charLimitInRow * text->getFontWidth() + yOffset + lineOffset,
                    screen);
            }
            lineOffset += (buffer.at(line)->getSize() / charLimitInRow + 1) * text->getFontWidth();
        }
        lastBufferSize = buffer.getSize();
    }
};

#endif