using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookPrice { get; set; }
        public string BookStatus { get; set; }
        public string BookType { get; set; }
        public string BookAuthor { get; set; }
    }
}
