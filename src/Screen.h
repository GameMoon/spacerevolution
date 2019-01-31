#ifndef SCREEN_H
#define SCREEN_H

#include <stdint.h>

#define SCREEN1_XOFFSET 61
#define SCREEN1_YOFFSET 183
#define SCREEN1_WIDTH 1024
#define SCREEN1_HEIGHT 768

#define SCREEN2_XOFFSET 1137
#define SCREEN2_YOFFSET 75
#define SCREEN2_WIDTH 720
#define SCREEN2_HEIGHT 480

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
        
        void draw(int x, int y, int r, int g, int b, int a = 255, int screen = 0){
            if(a == 255){
                if(screen == 0) setPixel(x + SCREEN1_XOFFSET, y + SCREEN1_YOFFSET, r, g, b, a);
                else if(screen == 1) setPixel(x + SCREEN2_XOFFSET, y + SCREEN2_YOFFSET, r, g, b, a);
                else if(screen == -1) setPixel(x , y , r, g, b, a);
            }
        }

        uint8_t * getPixels(){return pixels;}
        uint8_t getPixel(int index){return pixels[index];}

        void clearArea1(){

            for (int x = 0; x < SCREEN1_WIDTH; x++)
                for (int y = 0; y < SCREEN1_HEIGHT; y++)
                    setPixel(x + SCREEN1_XOFFSET, y + SCREEN1_YOFFSET, 0, 200, 0);
        }

        void clearArea2(){
            for (int x = 0; x < SCREEN2_WIDTH; x++)
                for (int y = 0; y < SCREEN2_HEIGHT; y++)
                    setPixel(x + SCREEN2_XOFFSET, y + SCREEN2_YOFFSET, 0, 0, 0);
        }
};

#endif