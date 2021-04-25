using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaBookLibrary.App.Models
{ 
    public enum Filters { Author, Category, Language, ISBN, Title, OnLoan, Available };
    class Library
    {
        List<Book> books;

        public List<Book> bookList(List<Book> bookList = null, int filterBy)
        {
            if (bookList == null)
            {
                Filters chosenFilter = new Filters();// kažkaip paduoti komandą, pagal ką filtruosim

                switch (chosenFilter)
                {
                    case Filters.Author:
                        bookList = books.FindAll(item => item.Author == Author);
                        break;
                    case Filters.Category:
                        bookList = books.FindAll(item => item.Category == Category);
                        break;
                    case Filters.Language:
                        bookList = books.FindAll(item => item.Language == Language);
                        break;
                    case Filters.ISBN:
                        bookList = books.FindAll(item => item.ISBN == ISBN);
                        break;
                    case Filters.Title:
                        bookList = books.FindAll(item => item.Title == Title);
                        break;
                    case Filters.OnLoan:
                        bookList = books.FindAll(item => item.OnLoan == OnLoan);
                        break;
                    case Filters.Available:
                        bookList = books.FindAll(item => item.(!OnLoan) == Available);
                        break;
                    default:
                        bookList = books;
                        break;
                }
                return bookList;
            }
        }

        public void displayLibraryCatalogue(List<Book> bookDisplay)
        {
            foreach (Book book in bookDisplay)
            {
                Console.WriteLine($"{book.ToString()} \r\n");
            }
        }
    }
}
