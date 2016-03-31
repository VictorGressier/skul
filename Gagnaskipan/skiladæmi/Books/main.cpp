// ****************************************************************
//
// This program implements an in-memory database of books using
// a vector and sorts them using the generic sort function from
// the algorithm library.
// ****************************************************************

#include <vector>
#include <algorithm>
#include "book.h"

using namespace std;

// Function prototypes
void AddNewBook(vector<Book> &bookdata);
void PrintBooks(vector<Book> &bookdata);
void SortBooks(vector<Book> &bookdata);
void PrintMenu();


int main()
{
    vector<Book> data;

    string choice;
    do
    {
        PrintMenu();
        cin >> choice;

        if(choice == "1")
        {
            AddNewBook(data);
        }
        else if (choice == "2")
        {
            PrintBooks(data);
        }

    }while(choice != "3");

    return 0;
}

void PrintMenu()
{
    cout << "Select from the following choices:" << endl
         << "1.\tAdd new book" << endl
         << "2.\tPrint listing sorted by author" << endl
         << "3.\tQuit" << endl;
}

void AddNewBook(vector<Book> &bookdata)
{
    string title, author, date;

    cout << "Enter title:" << endl;
    cin >> title;
    cout << "Enter author:" << endl;
    cin >> author;
    cout << "Enter date:" << endl;
    cin >> date;

    Book theBook(title, author, date);
    bookdata.push_back(theBook);
}

void PrintBooks(vector<Book> &bookdata)
{
    SortBooks(bookdata);
    cout << "The books entered so far, sorted alphabetically by author are:" << endl;
    vector<Book>::iterator it;
    for(it = bookdata.begin(); it != bookdata.end(); it++)
    {
        cout << "\t" << it->getAuthor() << ".  " << it->getTitle() << ".  " << it->getDate() << "." << endl;
    }
}

void SortBooks(vector<Book> &bookdata)
{
    sort(bookdata.begin(),bookdata.end());
}


