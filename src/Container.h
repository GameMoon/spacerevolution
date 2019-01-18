#ifndef CONTAINER_H
#define CONTAINER_H

#include "Object.h"

class Container
{
    Object** data;
    int size;
  public:
    Container(int size = 0): size(size){
        data = new Object*[size];
    }
    void add(Object * newObject){
        Object** temp = new Object*[size+1];
        for(int k = 0; k<size;k++){
            temp[k] = data[k];
        }
        temp[size] = newObject;
        delete[] data;
        data = temp;
        size++;
    }
    Object* at(int index){ return data[index];}
    Object ** getAll(){ return data;}
    int getSize(){ return size;}
};

#endif