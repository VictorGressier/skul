#include "book.h"


	Book::Book()
	{

	}

	Book::Book(string anAuthor, string aTitle, string aDate)
	{
	    author=anAuthor;
	    title=aTitle;
	    date=aDate;
	}

	string Book::getAuthor() const
	{
	    return author;
	}

	string Book::getTitle() const
	{
	    return title;
	}

	string Book::getDate() const
	{
	    return date;
	}

	bool operator <(const Book &book1, const Book &book2)
	{
        int compare = book1.getAuthor().compare(book2.getAuthor());

        if (compare < 0)
            return true;
        else
            return false;
	}

