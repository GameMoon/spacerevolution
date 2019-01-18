#ifndef SPRITE_H
#define SPRITE_H

class Sprite : Image{
    private:
        int numberOfFrames;
        int numberOfMovements;
        int currentFrame;
        int frameWidth;
        int frameHeight;

        int timeForFrame;
    public:
      Sprite(uint8_t *pixels = nullptr, int width = 0, int height = 0, int numberOfFrames = 0, int numberOfMovements = 0)
          : Image(pixels, width, height), numberOfFrames(numberOfFrames), numberOfMovements(numberOfMovements)
      {
          frameWidth = width / numberOfFrames;
          frameHeight = height / numberOfMovements;
          currentFrame = 1;
          timeForFrame = 0;
          }

        void draw(int xPos, int yPos,int movement, Screen *screen){
            for (int x = currentFrame*frameWidth; x < (currentFrame+1)*frameWidth; x += 1)
            {
                for (int y = movement * frameHeight; y < (movement+1) * frameHeight; y += 1)
                {
                    int imageOffset = (x + y * this->getWidth()) * 4;
                        screen->draw(
                            x + xPos - currentFrame* frameWidth,
                            y + yPos - movement * frameHeight,
                            this->getPixel(imageOffset),
                            this->getPixel(imageOffset + 1),
                            this->getPixel(imageOffset + 2),
                            this->getPixel(imageOffset + 3));
                }
            }
        }
        void updateFrame(int elapsedTime, int maxNoFrames){
            //printf("tf: %d dt: %d\n",timeForFrame,elapsedTime);
            if(timeForFrame < 0){
                currentFrame = (currentFrame + 1) % maxNoFrames;
                timeForFrame = 1000 / 12; // 12 fps 
            }
            timeForFrame -= elapsedTime;
        }
};

#endif