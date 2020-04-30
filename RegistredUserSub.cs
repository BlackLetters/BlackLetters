using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Services.Interfaces;
using Biblioteca.Models;
using Biblioteca.Context;
using System.Linq.Expressions;

namespace Biblioteca.Services.Repository
{
    public class RegistredUserSubRepository : RepositoryBase<RegistredUserSubRepository>, IRegistredUserSubRepository

    {
        public RegistredUserSubRepository(BibliotecaContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void Create(RegistredUserSub entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(RegistredUserSub entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            var found = RepositoryContext.RegistredUsers.Any(e => e.ID == id);
            return found;
        }

        public RegistredUserSub FindByCondition(Expression<Func<RegistredUserSub, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(RegistredUserSub entity)
        {
            throw new NotImplementedException();
        }

        List<RegistredUserSub> IRepositoryBase<RegistredUserSub>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
