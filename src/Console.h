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

  int bufferLimit;
  int numberOfLines;
  int charLimitInRow;
  int lastBufferSize;
  bool drawingDone;

  Container< Container<Image> > buffer;
public:
    Console(Image *image) : fontSprite(image)
    {
      text = new TextGenerator(image);
      xOffset = yOffset = 18;
      
      timeForFrame = 0;
      
      bufferLimit = numberOfLines = 0;
      charLimitInRow = 43;
      drawingDone = false;
    }

    void updateFrame(int elapsedTime)
    {
        if (timeForFrame < 0 && bufferLimit > 0)
        {
            timeForFrame = 1000 / 12;
        }
        timeForFrame -= elapsedTime;
    }
    void addText(const char * string){
        buffer.add(text->create(string));

        numberOfLines = 0;
        int commands = 0;
        for (int k = buffer.getSize()-1; k >= 0; k--)
        {
            numberOfLines += (buffer.at(k)->getSize() / charLimitInRow) + 1;
            commands++;
            if(numberOfLines == 28 ) break;
            
        }
        drawingDone = false;
        bufferLimit = commands;
    }

    void clear(){
        buffer.clear();
    }

    void draw(Screen * screen){
        
        if(drawingDone) return;

        screen->clearArea2();

        int lineOffset = numberOfLines*text->getFontWidth();
        if(buffer.getSize() == 0) return;

        for (int line = buffer.getSize()-1; line >= buffer.getSize() - bufferLimit; line--)
        {
            lineOffset -= (buffer.at(line)->getSize() / charLimitInRow + 1) * text->getFontWidth();
            for (int k = 0; k < buffer.at(line)->getSize(); k++)
            {
                buffer.at(line)->at(k)->drawConsole(
                    (k % charLimitInRow) * text->getFontWidth() + xOffset,
                    k / charLimitInRow * text->getFontWidth() + yOffset + lineOffset,
                    screen);
            }
        }
        drawingDone = true;
    }
};

#endif