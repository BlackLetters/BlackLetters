using Biblioteca.Context;
using Biblioteca.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.Repository
{
    public class RepositoryWrapper
    {
        private BibliotecaContext repoContext;

        private IAdminRepository _admin;

        public IAdminRepository Admin
        {
            get
            {
                if (_admin == null)
                {
                    _admin = new AdminRepository(repoContext);
                }

                return _admin;
            }
        }
    }
}
