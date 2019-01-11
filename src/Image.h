#ifndef IMAGE_H
#define IMAGE_H

class Image{
    char * pixels;
    public:
    Image(char * pixels = 0) : pixels(pixels) {}
    ~Image(){ delete pixels; }
};

#endif