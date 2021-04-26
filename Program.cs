using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Newtonsoft;
using Newtonsoft.Json;
using Models;

namespace VismaBookLibrary
{
    class Program
    {
        static JsonDataHandler _dataHandler;
        static AppData _appData;
        static BooksData _booksData;
        static BusinessLogic.BookLogic _bookLogic;

        static void SetupDependencies()
        {
            _dataHandler = new JsonDataHandler();
            _appData = new AppData(_dataHandler);
            _booksData = new BooksData(_appData);
            _bookLogic = new BusinessLogic.BookLogic(_booksData);
        }

        static void Main(string[] args)
        {
            SetupDependencies();
            DisplayMainMenu();
            
        }

        private static void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome, Visma Librarian. What would you like to do today?\r\n");
                Console.WriteLine("1. Add a book to the library catalogue.\r\n");
                Console.WriteLine("2. Display all the books listed in the library catalogue.\r\n");
                Console.WriteLine("3. Remove a book from the library catalogue.\r\n");
                Console.WriteLine("4. Request a book out on loan.\r\n");
                Console.WriteLine("5. Return a loaned book.\r\n");
                Console.WriteLine("6. End session.\r\n\r\n");
                Console.WriteLine("Please input a number, corresponding to the options above, as command confirming your choice");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        RegisterNewBook();
                        break;
                    case "2":
                        Console.Clear();
                        DisplayBooks();
                        break;
                    case "3":
                        Console.WriteLine("Please enter the ID of the book you wish to remove from the catalogue.");
                        int id = int.Parse(Console.ReadLine());
                        _bookLogic.DeleteBook(id);
                        Console.WriteLine("The book has been successfully removed from the library database.\r\n");
                        break;
                    //case "4":



                }

            }


        }
        static void RegisterNewBook()
        {
            //TODO add validations
            Console.WriteLine("Please enter the full name of the    book's author:");
            string author = Console.ReadLine();
            Console.WriteLine("Please enter the title of the book:");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter the category the book should be added to:");
            string category = Console.ReadLine();
            Console.WriteLine("Please enter the language of the book is published in:");
            string language = Console.ReadLine();
            Console.WriteLine("Please enter the ISBN of the book:");
            string isbn = Console.ReadLine();
            Console.WriteLine("Please enter the book's year of publication:");
            int publicationDate = int.Parse(Console.ReadLine());

            Book book = new Book(author, title, category, language, isbn, publicationDate);
            _bookLogic.SaveBook(book);
            Console.WriteLine("The book has been successfully added to the library catalogue. \r\n");
            
        }
        static void DisplayBooks()
        {
            Console.Clear();
           
            Console.WriteLine("Please choose how you wish to see the list of books available in our catalogue:");
            
            Console.WriteLine("1. Filter by Author:");
            Console.WriteLine("2. Filter by Title:");
            Console.WriteLine("3. Filter by Category:");
            Console.WriteLine("4. Filter by Language:");
            Console.WriteLine("5. Filter by ISBN:");
            Console.WriteLine("6. Filter by availability status:");
            Console.WriteLine("6. Filter by status - loaned out:");
            Console.WriteLine("7. Default view: all books in the catalogue");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Please provide the full name of the author.");
                    string author = Console.ReadLine();
                    var filteredBooks = _bookLogic.GetBooksByAuthor(author);
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine($"Book Id: {book.Id}; \r\n{book.Title}, by {book.Author}, {book.PublicationDate}; \r\ncategory:{book.Category}, language: {book.Language} \r\nISBN: {book.ISBN} \r\n");
                    }
                    break;
                case "2":
                    Console.WriteLine("Please provide the title of the book.");
                    string title = Console.ReadLine();
                    filteredBooks = _bookLogic.GetBooksByTitle(title);
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine($"Book Id: {book.Id}; \r\n{book.Title}, by {book.Author}, {book.PublicationDate}; \r\ncategory:{book.Category}, language: {book.Language} \r\nISBN: {book.ISBN} \r\n");
                    }
                    break;
                case "3":
                    Console.WriteLine("Please provide the book category.");
                    string category = Console.ReadLine();
                    filteredBooks = _bookLogic.GetBooksByCategory(category);
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine($"Book Id: {book.Id}; \r\n{book.Title}, by {book.Author}, {book.PublicationDate}; \r\ncategory:{book.Category}, language: {book.Language} \r\nISBN: {book.ISBN} \r\n");
                    }
                    break;
                case "4":
                    Console.WriteLine("Please provide the publishing language.");
                    string language = Console.ReadLine();
                    filteredBooks = _bookLogic.GetBooksByLanguage(language);
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine($"Book Id: {book.Id}; \r\n{book.Title}, by {book.Author}, {book.PublicationDate}; \r\ncategory:{book.Category}, language: {book.Language} \r\nISBN: {book.ISBN} \r\n");
                    }
                    break;
                case "5":
                    Console.WriteLine("Please provide the ISBN of the book.");
                    string isbn = Console.ReadLine();
                    filteredBooks = _bookLogic.GetBooksByISBN(isbn);
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine($"Book Id: {book.Id}; \r\n{book.Title}, by {book.Author}, {book.PublicationDate}; \r\ncategory:{book.Category}, language: {book.Language} \r\nISBN: {book.ISBN} \r\n");
                    }
                    break;
                case "6":
                    Console.WriteLine("Please choose a for available; b for borrowed books.");

                    string availabilityType = Console.ReadLine();
                    bool isAvailable;
                    
                    if (availabilityType == "a")
                    {
                        isAvailable = true;
                    } else
                    {
                        isAvailable = false;
                    }
                        filteredBooks = _bookLogic.GetBooksByAvailability(isAvailable);
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine($"Book Id: {book.Id}; \r\n{book.Title}, by {book.Author}, {book.PublicationDate}; \r\ncategory:{book.Category}, language: {book.Language} \r\nISBN: {book.ISBN} \r\n");
                    }
                    break;
                case "7":
                    filteredBooks = _bookLogic.GetBooks();
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine($"Book Id: {book.Id}; \r\n{book.Title}, by {book.Author}, {book.PublicationDate}; \r\ncategory:{book.Category}, language: {book.Language} \r\nISBN: {book.ISBN} \r\n");
                    }
                    break;
            }
            

            

        }
    }
}



             