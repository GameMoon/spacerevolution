#ifndef TILECONTROLLER_H
#define TILECONTROLLER_H

#include "Container.h"
#include "Image.h"
#include <stdint.h>
#include <math.h>

#define TILE_SIZE 32

class TileController{
    Image * tileSet;
    Container<Image> tiles;

    void generateTile(Image * baseImage)
    {
        tiles.add(baseImage);
        generateRotations(baseImage);
        Image *mirrorH = baseImage->mirror();
        tiles.add(mirrorH);
        generateRotations(mirrorH);
        Image *mirrorV = baseImage->mirror(false);
        tiles.add(mirrorV);
        generateRotations(mirrorV);
    }

    void generateRotations(Image *curImage)
    {
        for (int k = 0; k < 3; k++)
        {
            curImage = curImage->rotate();
            tiles.add(curImage);
        }
    }

    void generateTiles(){
        int noOfTiles = (tileSet->getWidth() / TILE_SIZE) * (tileSet->getHeight() / TILE_SIZE);
        int tilesInRow = tileSet->getWidth() / TILE_SIZE;
        int tilesInColumn = tileSet->getHeight() / TILE_SIZE;
        
       
        for( int c = 0; c < tilesInColumn; c++){
            for(int r = 0; r < tilesInRow; r++){
                uint8_t * tile = new uint8_t[TILE_SIZE*TILE_SIZE*4];
                for (int x = 0; x < TILE_SIZE; x++)
                {
                    for (int y = 0; y < TILE_SIZE; y++)
                    {
                        int offset = ( r*TILE_SIZE+x + ((c*TILE_SIZE+y)*tileSet->getWidth()) )*4;
                        int imageIndex = (x + y * TILE_SIZE ) *4;
                        tile[imageIndex] = tileSet->getPixel(offset);
                        tile[imageIndex + 1] = tileSet->getPixel(offset + 1);
                        tile[imageIndex + 2] = tileSet->getPixel(offset + 2);
                        tile[imageIndex + 3] = tileSet->getPixel(offset + 3);
                    }
                }
                generateTile(new Image(tile, TILE_SIZE, TILE_SIZE));
                
            }
        }

      
    }
    public:
        TileController(Image * tileSet) : tileSet(tileSet) {
            generateTiles();
            printf("Loaded Tiles: %d\n",tiles.getSize());
        }
        Image* getTile(int index){ return tiles.at(index);}

};
#endif