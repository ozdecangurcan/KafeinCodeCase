using Kcs.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kcs.DataAccess.Concrete.EntityFramework
{
    public class PersonDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=PersonDb;Trusted_Connection=True;Integrated Security=True");
        }

        public DbSet<Person> Persons { get; set; }
    }
}
