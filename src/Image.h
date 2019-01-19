#ifndef IMAGE_H
#define IMAGE_H

class Image{
    protected:
    uint8_t * pixels;
    int width;
    int height;
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

      void draw(int xPos, int yPos, Screen *screen)
      {
        for (int x = 0; x < width; x += 1)
        {
          for (int y = 0; y < height; y += 1)
          {
            int imageOffset = (x + y * width) * 4;
            screen->draw(
                x + xPos,
                y + yPos,
                this->getPixel(imageOffset),
                this->getPixel(imageOffset + 1),
                this->getPixel(imageOffset + 2),
                this->getPixel(imageOffset + 3));
          }
        }
      }
      int sinI(int degree){
        if(degree == 90) return 1;
        if(degree == 180) return 0;
        if(degree == 270) return -1;
        return 0;
      }
      int cosI(int degree){
        if(degree == 90) return 0;
        if(degree == 180) return -1;
        if(degree == 270) return 0;
        return 0;
      }

      Image* rotate(int omega)
      {
        if(width != height) return nullptr;

        uint8_t * rotatedPixels = new uint8_t[width*height*4];
        for (int x = 0; x < width; x++)
        {
          for (int y = 0; y < height; y++)
          {
              int centerX = width / 2;
              int centerY = height / 2;
              int translatedX = (x-centerX) * cosI(omega) - (y - centerY) * sinI(omega);
              int translatedY = (x - centerX) * sinI(omega) + (y - centerY) * cosI(omega);

              int offset = (translatedX+centerX + (translatedY+centerY)*width) *4;
              int originalOffset = (x+y*width)*4;

              rotatedPixels[offset] = this->getPixel(originalOffset);
              rotatedPixels[offset+1] = this->getPixel(originalOffset+1);
              rotatedPixels[offset+2] = this->getPixel(originalOffset+2);
              rotatedPixels[offset+3] = this->getPixel(originalOffset+3);
          }
        }
        return new Image(rotatedPixels,width,height);
      }
};

#endif