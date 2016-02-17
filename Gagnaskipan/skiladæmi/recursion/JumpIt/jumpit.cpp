#include <iostream>
#include "jumpit.h"
using namespace std;

const int PENALTY = 1000;	// Used to assign a very high cost

int jumpIt(const int board[], int startIndex, int endIndex)
{
    if(startIndex+2 >= endIndex)
        return board[endIndex];
    else if (board[startIndex + 1] < board[startIndex +2])
    {
        return jumpIt(board, startIndex+1, endIndex) + board[startIndex+1];
    }
    else
    {
        return jumpIt(board, startIndex+2, endIndex) + board[startIndex+2];
    }
}
