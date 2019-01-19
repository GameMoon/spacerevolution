#ifndef SCREEN_H
#define SCREEN_H

#include <stdint.h>

class Screen{
    uint8_t * pixels;
    int width;
    int height;

    public:
        Screen(int width, int height) : width(width), height(height){ pixels = new uint8_t[width*height*4];}
        ~Screen(){ delete pixels;}
        int getWidth(){ return width;}
        int getHeight(){return height;}
        int getSize(){ return width*height*4;}
       

        void setPixel(int x, int y, int r, int g, int b, int a = 255){
          
            int offset = (x + y * width) * 4;
            this->pixels[offset] = r;
            this->pixels[offset+1] = g; 
            this->pixels[offset+2] = b; 
            this->pixels[offset+3] = a;
        }
        
        void draw(int x, int y, int r, int g, int b, int a = 255){
            //Alpha blending
          /*  int offset = (x + y * width) * 4;
            
            int backR = this->pixels[offset];
            int backG = this->pixels[offset + 1];
            int backB = this->pixels[offset + 2];
            int backA = this->pixels[offset + 3];*/

            /*float srcA = a / 255.0;
            float dstA = backA / 255.0;

            float alphaConstant = (1.0-srcA)*dstA;
            float newAlpha = (srcA + alphaConstant);
            setPixel(x, y,
                     (srcA * r + alphaConstant * backR) / newAlpha,
                     (srcA * g + alphaConstant * backG) / newAlpha,
                     (srcA * b + alphaConstant * backB) / newAlpha,
                     (int) newAlpha * 255);*/
            if(a == 255){
             setPixel(x +61, y+183,r ,g, b, a);
            }
        }

        uint8_t * getPixels(){return pixels;}
        uint8_t getPixel(int index){return pixels[index];}

        void clearArea1(){
            
            for (int x = 0; x < 1024; x++)
                for (int y = 0; y < 768; y++)
                    setPixel(x+61,y+183,0,200,0);
        }

        void clearArea2(){
            for (int x = 0; x < 720; x++)
                for (int y = 0; y < 480; y++)
                    setPixel(x + 1137, y + 75, 0, 0, 200);
        }
};

#endif