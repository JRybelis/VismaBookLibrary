//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VismaBookLibrary.App.Controllers
//{
//    class PatronController
//    {
//        List<Patron> patrons;
//        Book book;
        
//        public void PatronBookCount(Patron patron, int bookId)
//        {
//         
                
//            } else if (book.OnLoan)
//            {
//                patron.PatronBooksOnLoan++;
                
//            } else if (book.ReturnBook(patron, bookId))
//            {
//                if (patron.PatronBooksOnLoan != 0 && patron.PatronBooksOnLoan! < 0) 
//                {
//                    patron.PatronBooksOnLoan--;
//                } 
//            }
//            JsonDataHandler patronJSON = new JsonDataHandler();
//            patronJSON.updateJSON();
//        }
//    }
//}
