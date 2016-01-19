#include "arraylist.h"

template<class T>
ArrayList<T>::ArrayList(int size)
{
    maxSize = size;
    currSize = 0;
    moveToStart();
    arr = new T[maxSize];
}

template<class T>
ArrayList<T>::~ArrayList()
{
    delete [] arr;
}

template<class T>
void ArrayList<T>::append(T elem) {
    if(currSize > maxSize) // List capacity exceeded
    {
        getBiggerArr();
    }
    arr[currSize] = elem;
    currSize++;
}

template<class T>
void ArrayList<T>::next() {
    if (currElemPos < currSize)
        currElemPos++;
}

template<class T>
void ArrayList<T>::prev() {
    if (currElemPos > 0)
        currElemPos--;
}

template<class T>
void ArrayList<T>::moveToStart() {
    currElemPos = 0;
}

template<class T>
void ArrayList<T>::moveToEnd() {
    currElemPos = currSize;
}

template<class T>
void ArrayList<T>::moveToPos(const int& pos) {
    if(pos < currSize && pos > 0)
    currElemPos = pos;
}

template<class T>
int ArrayList<T>::length() const {
    return currSize;
}

template<class T>
int ArrayList<T>::currPos() const {
    return currElemPos;
}

template<class T>
T ArrayList<T>::value() const {
        return arr[currElemPos];
}

template<class T>
void ArrayList<T>::getBiggerArr(){
    int newMaxSize = maxSize * 2;
    T* tmp = new T[newMaxSize];
    mergeArray(tmp);
    maxSize = newMaxSize;
}

template<class T>
void ArrayList<T>::mergeArray(T* tmp){
    for(int i = 0; i< maxSize; i++){
        tmp[i] = arr[i];
    }
    arr = tmp;
    delete[]tmp;
}

template<class T>
void ArrayList<T>::remove(){
    for(int i = currElemPos; i<currSize-1; i++){
        arr[i]=arr[i+1];
    }
    currSize--;
}

template<class T>
void ArrayList<T>::insert(const T& elem){
    if(currSize==maxSize)
        getBiggerArr();

    currSize++;

    for(int i = currSize; i>currElemPos; i--){
        arr[i+1]=arr[i];
    }
    arr[currElemPos]=elem;
}

template<class T>
void ArrayList<T>::clear(){
    currSize=0;
    currElemPos=0;
}

