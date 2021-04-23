﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VismaBookLibrary
{
    class Book
    {
        private decimal LateFee { get; set; } // per day
        public int Max_Loan_Period { get; set; }
        public int Book_Basket { get; set; }
        
        private string _author;

        public string Author
        {
            get => _author;
            private set 
            { 
                _author = value; 
            }
        }

        public string Title { get; private set; }
        public string Language { get; private set; }
        public string Category { get; private set; }


        private int _ISBN;
        public int ISBN { get => _ISBN; private set
            {
                Regex regex = new Regex(@"^[0-9]{13}$");
                if (regex.IsMatch(value.ToString()))
                {
                    _ISBN = value;
                } else
                {
                    Console.WriteLine("Please ensure that the ISBN number supplied is correct. /t The current standard is 13 digits in length. To convert ISBNS of old titles to it, please use the ISBN calculator at https://www.isbn-international.org");
                }
            }

        }
        private int _publicationDate;
        public int PublicationDate
        {
            get => _publicationDate; private set
            {
                Regex regex = new Regex(@"^[0-9]{4}$");
                if (regex.IsMatch(value.ToString()))
                {
                    _publicationDate = value;
                } else
                {
                    Console.WriteLine("Please ensure that the date of publication is correct. /t Accepted format: YYYY.");
                }
            }

        }

        private Patron _IssuedTo;

        private Patron IssuedTo { get; set; }

        private DateTime IssuedOn { get; set; }
        private bool OnLoan { get; set; }
        public Book( int max_loan_period = 60)
        {
            Max_Loan_Period = max_loan_period;
        }
        // returns status of the book
        public bool LoanBook(Patron patron, int days = 7)
        {
            if (days > Max_Loan_Period)
            {
                Console.WriteLine("The book cannot be issued for longer than {0} days. Please adjust the loan period.", Max_Loan_Period);
                return false; 
            } else
            {
                if (OnLoan)
                {
                    Console.WriteLine($"The book is already issued to {IssuedTo.Name}");
                    return false;
                } else
                {
                    OnLoan = true;
                    IssuedTo = patron;
                    IssuedOn = DateTime.Now;
                    Console.WriteLine("Book has been issued to PATRON-NAME-PLACEHOLDER.");
                    return true;
                }
            }
        }
        
        public bool ReturnBook(Patron patron)
        {
            if (IsLate())
            {
                int days = int.Parse((DateTime.Now - IssuedOn).TotalDays.ToString()) - Max_Loan_Period;
                decimal Penalty = ApplyPenalty(days);
            }
            return true;
        }

        private decimal ApplyPenalty(int days)
        {
            //throw new NotImplementedException();
        }

        private bool IsLate()
        {
            if ((DateTime.Now - IssuedOn).TotalDays > Max_Loan_Period)
            {
                return true;
            } else
            {
                return false;
            }
        }
        
    }
}