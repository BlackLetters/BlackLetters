using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Context
{
    public class BibliotecaContext: DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<RegistredUserSub> RegistredUserSubs { get; set; }
        public DbSet<RegistredUser> RegistredUsers { get; set; }
        public DbSet<UnregistredUser> UnregistredUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


    }
}
