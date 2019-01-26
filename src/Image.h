#ifndef IMAGE_H
#define IMAGE_H

#define TILE_SIZE 32

class Image{
    protected:
    uint8_t * pixels;
    int width;
    int height;
    int id;
    public:
      Image(uint8_t *pixels = nullptr, int width = 0, int height = 0) : pixels(pixels), width(width), height(height) {}
      ~Image() { delete pixels; }
      void setPixels(uint8_t* pixels){ this->pixels = pixels;}
      void setSize(int width, int height){ this->height = height; this->width = width;}
      int getWidth(){ return width;}
      int getHeight(){ return height;}
      uint8_t *getPixels() { return pixels; }
      uint8_t getPixel(int index) { return pixels[index]; }
      int getSize() { return width * height * 4; }
      int getID(){ return id;}
      void setID(int id){ this->id = id;}

      void draw(int xPos, int yPos, Screen *screen, int xOffset = 0, int yOffset = 0, int oWidth = -1, int oHeight = -1, int targetScreen = 0)
      {
        if (oWidth == -1) oWidth = width;
        if (oHeight == -1) oHeight = height;

        for (int x = xOffset; x < oWidth; x += 1)
        {
          for (int y = yOffset; y < oHeight; y += 1)
          {
            int imageOffset = (x + y * width) * 4;
            screen->draw(
                x + xPos,
                y + yPos,
                this->getPixel(imageOffset),
                this->getPixel(imageOffset + 1),
                this->getPixel(imageOffset + 2),
                this->getPixel(imageOffset + 3),
                targetScreen);
          }
        }
      }
      void drawConsole(int xPos, int yPos, Screen *screen){
        this->draw(xPos,yPos,screen,0,0,-1,-1,1);
      }
     
    
      Image* rotate()
      {
        if(width != height) return nullptr;

        uint8_t * rotatedPixels = new uint8_t[width*height*4];
        for (int x = 0; x < width; x++)
        {
          for (int y = 0; y < height; y++)
          {
              int translatedX = height-y-1;
              int translatedY = x;
              int offset = (translatedX + (translatedY)*width) *4;
              int originalOffset = (x+y*width)*4;

              rotatedPixels[offset] = this->getPixel(originalOffset);
              rotatedPixels[offset+1] = this->getPixel(originalOffset+1);
              rotatedPixels[offset+2] = this->getPixel(originalOffset+2);
              rotatedPixels[offset+3] = this->getPixel(originalOffset+3);
          }
        }
        return new Image(rotatedPixels,width,height);
      }

      Image* mirror(bool isHorizontal = true)
      {
        if(width != height) return nullptr;

        uint8_t * rotatedPixels = new uint8_t[width*height*4];
        int translatedX = 0;
        int translatedY = 0;
        for (int x = 0; x < width; x++)
        {
          for (int y = 0; y < height; y++)
          {
            if(isHorizontal){
              translatedX = width-1-x;
              translatedY = y;
            }
            else{
              translatedX = x;
              translatedY = height-1-y;
            }
            int offset = (translatedX + (translatedY)*width) * 4;
            int originalOffset = (x + y * width) * 4;

            rotatedPixels[offset] = this->getPixel(originalOffset);
            rotatedPixels[offset + 1] = this->getPixel(originalOffset + 1);
            rotatedPixels[offset + 2] = this->getPixel(originalOffset + 2);
            rotatedPixels[offset + 3] = this->getPixel(originalOffset + 3);
          }
        }
        return new Image(rotatedPixels,width,height);
      }
};

#endif