using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public int DateOfReturn { get; set; }
        public int DateOfAquire { get; set; }

        public ICollection<Book> Books { get; set; }
        public ICollection<RegistredUser> RegistredUsers { get; set; }
    }
}
