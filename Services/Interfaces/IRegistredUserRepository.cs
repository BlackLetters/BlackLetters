using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;

namespace Biblioteca.Services.Interfaces
{
    public interface IRegistredUserRepository : IRepositoryBase<RegistredUser>
    {
        public bool Exists(int id);
    }
}
