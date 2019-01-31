#ifndef TEXTGENERATOR_H
#define TEXTGENERATOR_H

#include "Image.h"

class TextGenerator
{
    Image * fontSprite;
    int fontWidth;

    Container<Image> alphabet;
    void initAlphabet(int numberOfCharacters,int r = 0, int g = 0, int b = 0){
        fontWidth = fontSprite->getWidth() / numberOfCharacters;

        for(int fontIndex = 0; fontIndex < numberOfCharacters; fontIndex++){
            uint8_t * fontPixels = new uint8_t[fontWidth*fontSprite->getHeight()*4];
            
            for(int x = 0; x < fontWidth; x++){
                for(int y = 0; y < fontSprite->getHeight(); y++){
                    int baseOffset = (x + fontIndex * fontWidth + y * fontSprite->getWidth()) * 4;
                    int fontImageOffset = (x/2+y/2*fontWidth/2)*4;

                   
                    fontPixels[fontImageOffset] = r;//fontSprite->getPixel(baseOffset);
                    fontPixels[fontImageOffset + 1] = g;//fontSprite->getPixel(baseOffset+1);
                    fontPixels[fontImageOffset + 2] = b;//fontSprite->getPixel(baseOffset+2);
                    fontPixels[fontImageOffset + 3] = fontSprite->getPixel(baseOffset+3);
                }
            }
            alphabet.add(new Image(fontPixels,fontWidth/2,fontSprite->getHeight()/2));
        }

        //Space
        uint8_t *fontPixels = new uint8_t[fontWidth * fontSprite->getHeight() * 4];
        alphabet.add(new Image(fontPixels, fontWidth, fontSprite->getHeight()));
    }
    
    public: 
    TextGenerator(Image * image) : fontSprite(image) {
        fontWidth = 0;
        initAlphabet(91,0,100,0);
    }

    Container<Image>* create(const char * text){
        Container<Image> * characterImages = new Container<Image>();

        for(int k = 0; k< strlen(text);k++){
            characterImages->add(alphabet.at(getIndex(text[k])));
        }

        return characterImages;
    }
    
    int getIndex(char c){
        if(c >= 'a' && c <='z') return (int)c - 97; //26
        else if(c >= 'A' && c <='Z') return (int)c - 39;//26
        else if(c >= '0' && c <='9') return (int)c + 4; //10
        else if(c >= '!' && c <= '%') return (int)c + 29; //5
        else if(c >= '(' && c <= '/') return (int)c + 27; //8

        else if(c >= ':' && c <= '@') return (int)c + 17; //7
        else if(c >= '[' && c <= ']') return (int)c - 9; //3
        else if(c >= '_' && c <= '`') return (int)c - 10; //2
        else if(c >= '{' && c <= '~') return (int)c - 36;
        else return alphabet.getSize()-1;
    }

    int getFontWidth(){
        return fontWidth/2;
    }
};

#endif