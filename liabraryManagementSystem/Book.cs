using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liabraryManagementSystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; } = string.Empty;

        public Book(string title,string author,string ISBN) 
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = ISBN;
        }
    }
}
