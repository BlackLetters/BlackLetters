using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Services.Interfaces;


namespace Biblioteca.Services.Repository
{
    public class RegistredUserRepository : RepositoryBase<RegistredUserRepository>, IRegistredUserRepository
    {
        public RegistredUserRepository(BibliotecaContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void Create(RegistredUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(RegistredUser entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            var found = RepositoryContext.RegistredUsers.Any(e => e.ID == id);
            return found;
        }

        public RegistredUser FindByCondition(Expression<Func<RegistredUser, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(RegistredUser entity)
        {
            throw new NotImplementedException();
        }

        List<RegistredUser> IRepositoryBase<RegistredUser>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}

