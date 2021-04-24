﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace VismaBookLibrary.App.Controllers
{
    class DataHandler
    {
        List<Patron> patrons;
        List<Book> books;
        public void updateJSON()
        {
            string json = JsonConvert.SerializeObject(patrons, Formatting.Indented);
            File.WriteAllText("patrons.json", json);
            
            json = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText("books.json", json);
        }
        
        public void readJSON()
        {
            if (File.Exists("patrons.json"))
            {
                string json = File.ReadAllText("patrons.json");
                if (json == "")
                {
                   patrons = new List<Patron>();
                } else
                {
                    patrons = JsonConvert.DeserializeObject<List<Patron>>(json);
                }
            } else
            {
                patrons = new List<Patron>();
            }
        }
    }
}
