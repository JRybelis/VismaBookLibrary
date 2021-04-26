using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class BooksFilter
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public bool? IsAvailable { get; set; }
        public string PatronName { get; set; }
        
    }
}
