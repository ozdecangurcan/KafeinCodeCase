using Kcs.Core.DataAccess;
using Kcs.Core.DataAccess.EntityFramework;
using Kcs.DataAccess.Abstract;
using Kcs.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kcs.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfRepositoryBase<Person, PersonDbContext>, IPersonDal
    {
        public void ResetPassword(Person person)
        {
            using (var context = new PersonDbContext())
            {
                var updatedEntity = context.Entry(person);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Person LoginPerson(string email, string password)
        {
            using (var context = new PersonDbContext())
            {
                return context.Persons.Where(x => x.PersonEmail == email && x.Password == password)?.FirstOrDefault();
            }
        }

        public Person GetPersonWithMail(string email)
        {
            using (var context = new PersonDbContext())
            {
                return context.Persons.Where(x => x.PersonEmail == email)?.FirstOrDefault();
            }
        }
    }
}
