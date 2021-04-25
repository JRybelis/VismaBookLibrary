using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaBookLibrary.App.Controllers
{
    class PatronController
    {
        List<Patron> patrons;
        Book book;
        
        public void PatronBookCount(Patron patron)
        {
            if (patron.PatronBooksOnLoan >= 3)
            {
                Console.WriteLine("The patron has exceeded the number of books allowed to take out. Please ensure no more than three books at a time are on loan for each patron.");
                
            } else if (book.OnLoan)
            {
                patron.PatronBooksOnLoan++;
                
            } else if (book.ReturnBook(patron))
            {
                if (patron.PatronBooksOnLoan != 0 && patron.PatronBooksOnLoan! < 0) 
                {
                    patron.PatronBooksOnLoan--;
                } 
            }
            DataHandler patronJSON = new DataHandler();
            patronJSON.updateJSON();
            
        }
    }
}
