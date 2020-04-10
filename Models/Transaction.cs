using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int TransactionDateOfReturn { get; set; }
        public int TransactionDateOfAquire { get; set; }

        public ICollection<Book> Books { get; set; }
        public ICollection<RegistredUser> RegistredUsers { get; set; }
    }
}
