#ifndef IMAGE_H
#define IMAGE_H

class Image{
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
};

#endif