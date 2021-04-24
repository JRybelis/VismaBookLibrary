using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VismaBookLibrary
{
    class Library
    {
        public List<Shelf> Shelves { get; set; }
        public List<Patron> Patrons { get; set; }

        Library(List<Shelf> shelves, List<Patron> patrons)
        {
            Shelves = shelves;
            Patrons = patrons;
        }
        
        public Library Load()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "library_store.json";
            return path;
        }
        public void Save()
        {

        }
    }
}
