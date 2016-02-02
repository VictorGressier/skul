#include "LinkedList.h"

template<class T>
LinkedList<T>::LinkedList()
{
   header = new Node<T>(0,NULL,NULL);
   trailer = new Node<T>(0,NULL,NULL);
   init();
}

template<class T>
LinkedList<T>::LinkedList(LinkedList<T>& lis)
{

}

template<class T>
LinkedList<T>::~LinkedList()
{
    removeAll();
    delete header;
    delete trailer;
}

template<class T>
void LinkedList<T>::next()
{
    if(currNode == trailer)
        return;
    else
        currNode=currNode->getNext();
}

template<class T>
void LinkedList<T>::prev()
{
    if(currNode->getPrev() == header)
        return;
    else
        currNode=currNode->getPrev();
}

template<class T>
void LinkedList<T>::moveToStart()
{
    currNode = header->getNext();
}

template<class T>
void LinkedList<T>::moveToEnd()
{
    currNode = trailer;
}

template<class T>
void LinkedList<T>::moveToPos(int pos)
{
    moveToStart();

    for(int i = 0; i<pos; i++)
    {
        next();
    }
}

template<class T>
int LinkedList<T>::length() const
{
    return currSize;
}

template<class T>
T LinkedList<T>::value() const
{
    return currNode->getData();
}

template<class T>
bool LinkedList<T>::empty() const
{
     if(currSize == 0)
        return true;
     else
        return false;
}

template<class T>
void LinkedList<T>::append(T elem)
{
    insert(trailer, elem);
}

template<class T>
void LinkedList<T>::insert(const T& elem)
{
    insert(currNode, elem);
    currNode = currNode->getPrev();
}

template<class T>
T LinkedList<T>::remove()
{
    if(currNode == trailer)
        return 0;

    Node<T>* tmp = currNode;
    currNode = tmp->getNext();
    currNode->setPrev(tmp->getPrev());
    tmp->getPrev()->setPrev(currNode);

    currSize--;

    T elem = tmp->getData();

    delete tmp;

    return elem;
}

template<class T>
void LinkedList<T>::clear()
{
    removeAll();
    init();
}

template<class T>
Node<T>* LinkedList<T>::end() const
{
     return trailer;
}

template<class T>
Node<T>* LinkedList<T>::getCurrNode() const
{
    return currNode;
}

template<class T>
void LinkedList<T>::insert(Node<T>* beforeMe, const T& elem)
{
    Node<T>* newNode = new Node<T>(elem,beforeMe->getPrev(),beforeMe);
    beforeMe->getPrev()->setNext(newNode);
    beforeMe->setPrev(newNode);

    currSize++;
}

template<class T>
void LinkedList<T>::removeAll()
{
    for(Node<T>* iter = header->getNext(); iter!=NULL; iter=iter->getNext())
    {
       if(iter->getPrev()!=header)
            delete iter->getPrev();
    }
}

template<class T>
void LinkedList<T>::init()
{
    header->setNext(trailer);
    trailer->setPrev(header);
    currSize = 0;
    currNode = trailer;
}
