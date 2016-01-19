#ifndef MATRIX_H
#define MATRIX_H

const int MAX = 5;

class Matrix
{
    public:
        Matrix();
        Matrix(int x, int y);
    private:
        int arr[MAX][MAX];
};

#endif // MATRIX_H
