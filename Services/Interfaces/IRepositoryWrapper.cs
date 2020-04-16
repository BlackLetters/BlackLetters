using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.Interfaces
{
    public interface IRepositoryWrapper
    {
        public IAdminRepository Admin { get; }

        public void Save();
    }
}
