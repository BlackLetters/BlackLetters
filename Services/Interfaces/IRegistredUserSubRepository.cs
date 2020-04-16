using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.Interfaces
{
    interface IRegistredUserSubRepository: IRepositoryBase <RegistredUserSub>
    {
        public bool Exists (int ID);
    }
}
