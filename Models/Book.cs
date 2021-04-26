//    using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Text.RegularExpressions;

//namespace VismaBookLibrary
//{
//    class Book
//    {
//        List<Book> books;
//        private decimal LateFee { get; set; } // per day
//        public int MaxLoanPeriodDays { get; set; }
//        public int BookBasket { get; set; }

//        private Array _author;
//        public Array Author
//        {
//            get => _author;
//            private set 
//            { 
//                _author = value; 
//            }
//        }

//        public string Title { get; private set; }

//        public string Language { get; private set; }

//        private string _category;
//        public string Category 
//        { 
//            get => _category;
//            private set
//            {
//                _category = value;
//            }
//        }

//        private string _iSBN;
//        public string ISBN { get => _iSBN; private set
//            {
//                Regex regex = new Regex(@"^[0-9]{13}$");
//                if (regex.IsMatch(value.ToString()))
//                {
//                    _iSBN = value;
//                } else
//                {
//                    Console.WriteLine("Please ensure that the ISBN number supplied is correct. /t The current standard is 13 digits in length. To convert ISBNS of old titles to it, please use the ISBN calculator at https://www.isbn-international.org");
//                }
//            }

//        }

//        private string _publicationDate;
//        public string PublicationDate
//        {
//            get => _publicationDate; private set
//            {
//                Regex regex = new Regex(@"^[0-9]{4}$");
//                if (regex.IsMatch(value.ToString()))
//                {
//                    _publicationDate = value;
//                } else
//                {
//                    Console.WriteLine("Please ensure that the date of publication is correct. /t Accepted format: YYYY.");
//                }
//            }

//        }

//        internal int id;

//        private Patron _issuedTo;

//        private Patron IssuedTo { get;  set; }

//        private DateTime IssuedOn { get; set; }

//        private bool _onLoan;
//        public bool OnLoan 
//        { 
//            get => _onLoan;
//            private set
//            {
//                _onLoan = value;
//            }
//        }
//        public Book(Array author,
//                    string title,
//                    string language,
//                    string category,
//                    string isbn,
//                    string publicationDate,
//                    int maxLoanPeriod = 60,
//                    decimal lateFee = 0.25m)
//        {
//            Author = author;
//            Title = title;
//            Language = language;
//            Category = category.Trim();
//            ISBN = isbn;
//            PublicationDate = publicationDate;
//            MaxLoanPeriodDays = maxLoanPeriod;
//            LateFee = lateFee;
//        }
//        // returns status of the book
//        public bool LoanBook(Patron patron, int bookId, int requestedLoanPeriodDays = 7)
//        {
//            Book requestedBook = books.Find(item => item.id == bookId);

//           
//       
//        public bool ReturnBook(Patron patron, int bookId)
//        {
//    
//            {
//                bookBeingReturned.OnLoan = false;
//                bookBeingReturned.IssuedTo = null;
//                Console.WriteLine("The book has been returned. Thank you.");
//            }
//            return true;
//        }

//        private decimal ApplyPenalty(int days)
//        {
//            //throw new NotImplementedException();
//            Console.WriteLine("FUNNY MESSAGE PLACEHOLDER");
//            return days * LateFee;
//        }

//        private bool IsLate()
//        {
//            if ((DateTime.Now - IssuedOn).TotalDays > MaxLoanPeriodDays)
//            {
//                return true;
//            } else
//            {
//                return false;
//            }
//        }

//    }
//}
