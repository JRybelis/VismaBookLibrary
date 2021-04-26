using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Models
{
    public class Patron
    {
        public string Name { get; set; }
        public DateTimeOffset LoanDate { get; set; }
        public DateTimeOffset LoanUntilDate { get; set; }
    }
}
