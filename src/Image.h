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
};

#endif