#ifndef CONTAINER_H
#define CONTAINER_H

template <class myType>
class Container
{
    myType** data;
    int size;
  public:
    Container(int size = 0): size(size){
        data = new myType*[size];
    }
    ~Container(){ delete data;}

    void add(myType *newObject)
    {
        myType **temp = new myType *[size + 1];
        for(int k = 0; k<size;k++){
            temp[k] = data[k];
        }
        temp[size] = newObject;
        delete[] data;
        data = temp;
        size++;
    }
    myType* at(int index){ return data[index];}
    myType ** getAll(){ return data;}
    int getSize(){ return size;}
    
    void clear(){
        for(int k = 0; k <size; k++){
            delete data[k];
        }
        delete data;

        size = 0;
        data = new myType *[size];
    }
    void erase(){
        size = 0;
        delete data;
        data = new myType *[size];
    }
};

#endif