﻿using Biblioteca.Context;
using Biblioteca.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Biblioteca.Services.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BibliotecaContext RepositoryContext { get; set; }

        public IAdminRepository Admin => throw new NotImplementedException();

        public IBookRepository Book => throw new NotImplementedException();

        public IRegistredUserRepository RegistredUser => throw new NotImplementedException();

        public IRegistredUserSubRepository RegistredUserSub => throw new NotImplementedException();

        public RepositoryBase(BibliotecaContext RepositoryContext)
        {
            this.RepositoryContext = RepositoryContext;            
        }

        public List<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().ToList();
        }

        public T FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).SingleOrDefault();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
