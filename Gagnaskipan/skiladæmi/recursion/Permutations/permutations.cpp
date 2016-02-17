// ***************************************************************
// This is the implementation file for the Permutation class
// ***************************************************************
#include "permutations.h"

// Default constructor
Permutations::Permutations() : myPerms(NULL) {
}

// Destructor
Permutations::~Permutations() {
    removeAll();
}

// Generates permutations for set of size n
void Permutations::generate(int n) {
    if (myPerms != NULL) { // First clean the permutations if necessary
        removeAll();
    }

    int* aSet = new int[n];
    // Populate the set with the first n whole numbers
    for (int i = 0; i < n; i++) {
        aSet[i] = i+1;
    }

    // Use the recursive permutations function to generate all the permutations
    myPerms = permutate(aSet, n);
    // Deallocate aSet
    delete [] aSet;
}

// Prints all the permutations
void Permutations::print() const
{
    for(NodePtr tmp = myPerms; tmp != NULL; tmp = tmp->next)
    {
        printSet(tmp->setPtr, tmp->setSize);
    }
    cout << endl;
}

// Private functions start here
void Permutations::printSet(int set[], int size) const {
    cout << "{";
    for (int i = 0; i < size; i++) {
        if (i > 0) {
            cout << ",";
        }
        cout << set[i];
    }
    cout << "}";
}

void Permutations::remove(NodePtr node)
{
    delete [] node->setPtr;  // delete the set inside the node
    delete node;             // delete the node
}

// Remove every node from the list
void Permutations::removeAll()
{
    while (myPerms != NULL) {
        NodePtr next = myPerms->next;
        remove(myPerms);              // delete this node
        myPerms = next;
    }
}

void Permutations::insert(int num, NodePtr smaller, NodePtr& larger)
{
// For each permutation of the smaller list, make a permutation (pointed to by 'larger')
// that includes the number 'num' in each position

    NodePtr tmp = larger;

    while (smaller != NULL)
    {
        for (int i = 0; i <= smaller->setSize; i++)
        {
            int* arr = new int[num];
            int ins = 1;

            for (int j = 0; j <= smaller->setSize; j++)
            {

                if(i==j)
                {
                    arr[j]=num;
                }
                else
                {
                    arr[j]=ins;
                    ins++;
                }
            }
            tmp->setPtr = arr;
            tmp->setSize = num;
            tmp->next = new Node;
            tmp = tmp->next;
        }
        cout << "done!!";
        // Delete the node we just used, and move to the next one
        NodePtr next = smaller->next;
        remove(smaller);
        smaller = next;
    }

}

// Recursive function that returns a list containing all of the permutations of the set
NodePtr Permutations::permutate(int set[], int size)
{
    NodePtr small;
    NodePtr large;
    if(size==1)
    {
        small = new Node;
        small->setPtr=set;
        small->setSize=1;
        insert(size, small, large);
        return large;
    }
    else
    {
        small->setSize = size-1;
        small->setPtr = set;
        permutate(set,size-1);
        small = large;
        insert(size,small, large);
        return large;
    }
}




