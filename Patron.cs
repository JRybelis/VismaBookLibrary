using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VismaBookLibrary
{
    class Patron
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                Regex regex = new Regex(@"^[A-Za-Z ]+$");
                if (regex.IsMatch(value))
                {
                    _name = value;
                }
                else
                {
                    _name = "DEFAULT";
                    Console.WriteLine("Please enter a valid name. /t Only Latin alphabet without special characters or digits allowed.");
                }

            }
        }

        private int _patronID;
        public int PatronID
        {
            get => _patronID;
            set
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.IsMatch(value.ToString()))
                {
                    _patronID = value;
                }
                else
                {
                    Console.WriteLine("Please enter a valid ID. /t Only digits are allowed.");
                }
            }
        }

        public Patron(string name, int patronID)
        {
            Name = name;
            PatronID = patronID;
        }
    }
}
