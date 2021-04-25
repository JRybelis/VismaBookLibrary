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

        static void Main(string[] args)
        {
            SetupDependencies();

            var book = new Book
            {
                Author = "aa2",
                Category = "vv2"
            };

            _bookLogic.SaveBook(book);
        }

        private static void DisplayMainMenu()
        {

        }

        static void SetupDependencies()
        {
            _dataHandler = new JsonDataHandler();
            _appData = new AppData(_dataHandler);
            _booksData = new BooksData(_appData);
            _bookLogic = new BusinessLogic.BookLogic(_booksData);
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VismaBookLibrary.App.Views
//{
//    class LandingPage
//    {

//        public void programDisplay()
//        {
//            while (true)
//            {
//                Console.WriteLine("Welcome, Visma Librarian. What would you like to do today?\r\n");
//                Console.WriteLine("1. Add a book to the library catalogue.\r\n");
//                Console.WriteLine("2. Remove a book from the library catalogue.\r\n");
//                Console.WriteLine("3. Display all the books listed in the library catalogue.\r\n");

//                Console.WriteLine("4. Request a book out on loan.\r\n");
//                Console.WriteLine("5. Return a loaned book.\r\n");
//                Console.WriteLine("6. End session.\r\n\r\n");
//                Console.WriteLine("Please input a number, corresponding to the options above, as command confirming your choice");
//                string userInput = Console.ReadLine();

//                switch (userInput)
//                {
//                    case "1":
//                        createBookRecord();
//                }

//            }
//        }
//            void SaveBook()
//            {
//                Console.Clear();

//                Console.WriteLine("Please enter the title of the book:");
//                string title = Console.ReadLine(); // cia foreachint reik, kad sudet kelis autorius? 
//                Console.WriteLine("Please enter the full name of the book's author, separated by comma, if there are multiple authors:");
//                Array author = Console.ReadLine();
//                Console.WriteLine("Please enter the category the book should be added to:");
//                string category = Console.ReadLine();
//                Console.WriteLine("Please enter the language of the book is published in:");
//                string language = Console.ReadLine();
//                Console.WriteLine("Please enter the ISBN of the book:");
//                string iSBN = Console.ReadLine();
//                Console.WriteLine("Please enter the book's year of publication:");
//                string publicationDate = Console.ReadLine().ToString();

//                Book book = new Book(author, title, language, category, iSBN, publicationDate)
//booklogic save method

//            }

//    }
//}
