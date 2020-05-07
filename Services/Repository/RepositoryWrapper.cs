using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private BibliotecaContext repoContext;

        private IAdminRepository _admin;

        private IRegistredUserRepository _registredUser;

        private IRegistredUserSubRepository _registredUserSub;

        private IBookRepository _book;

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
        public IRegistredUserRepository RegistredUser
        {
            get
            {
                if (_registredUser == null)
                {
                    _registredUser = new RegistredUserRepository(repoContext);
                }

                return _registredUser;
            }
        }
        public IRegistredUserSubRepository RegistredUserSub
        {
            get
            {
                if (_registredUserSub == null)
                {
                    _registredUserSub = new RegistredUserSubRepository(repoContext);
                }

                return _registredUserSub;
            }
        }
        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(repoContext);
                }

                return _book;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
