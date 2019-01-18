#ifndef SPRITE_H
#define SPRITE_H

class Sprite : public Image{
    private:
        int numberOfFrames;
        int numberOfMovements;
        int currentFrame;
        int currentMovement;
        int maxNumberOfFrames;

        int frameWidth;
        int frameHeight;

        int timeForFrame;
        int frameXoffset;
        int frameYoffset;
    public:
      Sprite(uint8_t *pixels = nullptr, int width = 0, int height = 0, int numberOfFrames = 0, int numberOfMovements = 0)
          : Image(pixels, width, height), numberOfFrames(numberOfFrames), numberOfMovements(numberOfMovements)
      {
          frameWidth = width / numberOfFrames;
          frameHeight = height / numberOfMovements;

          maxNumberOfFrames = numberOfMovements;
          currentFrame = 0;
          timeForFrame = 0;
          currentMovement = 0;

          frameXoffset = 0;
          frameYoffset = 0;
       }

        int getFrameWidth(){ return frameWidth;}
        int getFrameHeight(){ return frameHeight;}

        void draw(int xPos, int yPos, Screen *screen){
            for (int x = currentFrame * frameWidth ; x < (currentFrame + 1) * frameWidth; x += 1)
            {
                for (int y = currentMovement * frameHeight ; y < (currentMovement + 1) * frameHeight; y += 1)
                {
                    int imageOffset = (x + y * this->getWidth()) * 4;
                    screen->draw(
                        x + xPos - currentFrame * frameWidth,
                        y + yPos - currentMovement * frameHeight,
                        this->getPixel(imageOffset),
                        this->getPixel(imageOffset + 1),
                        this->getPixel(imageOffset + 2),
                        this->getPixel(imageOffset + 3));
                }
            }
        }
        void updateFrame(int elapsedTime){
            if (timeForFrame < 0)
            {
                    currentFrame = (currentFrame + 1) % maxNumberOfFrames;
                    timeForFrame = 1000 / 12; // 12 fps 
            }
            timeForFrame -= elapsedTime;
        }

        void setCurrentFrame(int frame){ this->currentFrame = frame;}
        void setCurrentMovement(int movement, int maxNumberOfFrames = -1) {
            if (maxNumberOfFrames == -1) maxNumberOfFrames = numberOfMovements;
            this->maxNumberOfFrames = maxNumberOfFrames;

            this->currentMovement = movement; 
        }
};

#endif