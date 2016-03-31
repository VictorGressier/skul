#include "binarysearchtree.h"
#include "binarytree.cpp"


template <class T>
BinarySearchTree<T>::BinarySearchTree() : BinaryTree<T>()
{
}

template <class T>
BinarySearchTree<T>::BinarySearchTree(const T& rootItem) : BinaryTree<T>(rootItem)
{
}

template <class T>
BinarySearchTree<T>::~BinarySearchTree()
{
}

template <class T>
void BinarySearchTree<T>::insert(const T& anItem)
{
    insertAt(BinaryTree<T>::root, anItem);
}

template <class T>
void BinarySearchTree<T>::insertAt(BinaryNode<T> *& node, const T& anItem)
{
    if(node == NULL)
    {
        node = new BinaryNode<T>(anItem);
    }
    else if(anItem < node->item)
    {
        insertAt(node->leftChild, anItem);
    }
    else if(anItem > node->item)
    {
        insertAt(node->rightChild, anItem);
    }
}

template <class T>
BinaryNode<T>* BinarySearchTree<T>::maxNode() const
{
    if(BinaryTree<T>::root != NULL)
        return maxNode(BinaryTree<T>::root);
    else
        return NULL;
}

template <class T>
BinaryNode<T>* BinarySearchTree<T>::maxNode(BinaryNode<T> *node) const
{
    if(node->rightChild == NULL)
        return node;
    else
    {
        return maxNode(node->rightChild);
    }
}

template <class T>
BinaryNode<T>* BinarySearchTree<T>::minNode() const
{
    if(BinaryTree<T>::root!=NULL)
        return minNode(BinaryTree<T>::root);
    else
    {
        return NULL;
    }
}

template <class T>
BinaryNode<T>* BinarySearchTree<T>::minNode(BinaryNode<T> *node) const
{
    if(node->leftChild == NULL)
        return node;
    else
    {
        return minNode(node->leftChild);
    }
}

template <class T>
BinaryNode<T>* BinarySearchTree<T>::findAt(BinaryNode<T> * node, const T& anItem) const
// Retrieves an item starting searching at node
{
    if (node == NULL) {      // Then the item was not found
        return NULL;
    }
    else if (anItem == node->item) { // Then found
        return node;
    }
    else if (anItem < node->item) {  // Search in the left tree
        return (findAt(node->leftChild, anItem));
    }
    else {                            // Search in the right tree
        return (findAt(node->rightChild, anItem));
    }
}

template <class T>
void BinarySearchTree<T>::remove(const T& anItem)
{
    removeAt(BinaryTree<T>::root, anItem);
}


template <class T>
void BinarySearchTree<T>::removeAt(BinaryNode<T> *& node, const T& anItem)
{
    BinaryNode<T>* pabbi = NULL;
    BinaryNode<T>* current = node;
    bool found = false;

    while(!found && current!=NULL)
    {
        if(current->item == anItem)
        {
            found = true;
        }
        else
        {
            pabbi = current;
            if(anItem > current->item)
                current = current->rightChild;
            else
                current = current->leftChild;
        }
    }
    //if it was not found
    if(found == false)
    {
        return;
    }
    //if it has no child
    else if(current->isLeaf())
    {
        if(pabbi == NULL)
        {
            BinaryTree<T>::root=NULL;
        }
        else
        {
            if(pabbi->leftChild == current)
            {
                pabbi->leftChild = NULL;
            }
            else
            {
                pabbi->rightChild = NULL;
            }
        }
        removeNode(current);
    }
    //if it has 1 child
    else if((current->leftChild==NULL && current->rightChild != NULL) || (current->leftChild != NULL && current->rightChild==NULL))
    {
        if(current->leftChild!=NULL)
        {
            if(pabbi == NULL)
            {
                BinaryTree<T>::root = current->leftChild;
                removeNode(current);
            }
            else if(pabbi->leftChild == current)
            {
                pabbi->leftChild = current->leftChild;
                removeNode(current);
            }
            else
            {
                pabbi->rightChild = current->leftChild;
                removeNode(current);
            }
        }
        else
        {
            if(pabbi == NULL)
            {
                BinaryTree<T>::root = current->rightChild;
                removeNode(current);
            }
            else if(pabbi->leftChild == current)
            {
                pabbi->leftChild = current->rightChild;
                removeNode(current);
            }
            else
            {
                pabbi->rightChild = current->rightChild;
                removeNode(current);
            }
        }
    }
    //if it has 2 childs
    else if(current->leftChild!=NULL && current->rightChild!=NULL)
    {
        T elem = processLeftmost(current);
        current->item = elem;
    }

}

template <class T>
void BinarySearchTree<T>::removeNode(BinaryNode<T> *& node)
{
    delete node;
}

template <class T>
T BinarySearchTree<T>::processLeftmost(BinaryNode<T> *& node)
{
    BinaryNode<T>* temp = minNode(node->rightChild);
    T elem = temp->item;
    remove(elem);
    return elem;
}

template <class T>
BinaryNode<T>* BinarySearchTree<T>::find(const T& anItem) const // Retrieves the node corresponding to the item. If not found, returns null
{
    return (findAt(BinaryTree<T>::root, anItem));
}
