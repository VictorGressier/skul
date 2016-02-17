#include "palindrome.h"

bool palindrome(const char a[], int first, int last)
{
    if(first >= last)
        return true;
    else if(a[first]==a[last])
    {
        first++;
        last--;
        return palindrome(a, first, last);
    }
    else
        return false;
}
