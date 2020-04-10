using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class RegistredUser
    {
        public int RegistredUserID { get; set; }
        public string RegistredUserFirstName { get; set; }
        public string RegistredUserLastName { get; set; }
        public string RegistredUserEmail { get; set; }
        public string RegistredUserPassword { get; set; }
    }
}
