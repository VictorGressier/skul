#ifndef ARRAYLIST_H
#define ARRAYLIST_H
template <class T>
class ArrayList
{
    public:
        ArrayList(int size);            // Constructor
        ~ArrayList();                   // Destructor
        void append (T elem);           // Appends an element at the end of the list
        void next();                    // Moves the current position one step right
        void prev();                    // Moves the current position on step left
        void moveToStart();             // Set the current position to the start of the list
        void moveToEnd();               // Set the current position to the end of the list
        void moveToPos(const int& pos); // set the current position to the new pos member
        int currPos() const;            // Returns the position of the current element
        int length() const;             // Returns the current length of the list
        T value() const;                // Returns the current element
        void remove();                  // Removes the current element
        void insert(const T& elem);     // Inserts the elem before currentpos
        void clear();                   // Clears the list

    private:
        int maxSize;        // Maximum size of list
        int currSize;       // Current number of list items
        int currElemPos;    // Position of the current element of the list
        T* arr;           // A pointer to the array holding the list elements
        void getBiggerArr();        //doubles the max size of the array
        void mergeArray(T* tmp);    //merge an array to another array
};

#endif // ARRAYLIST_H
