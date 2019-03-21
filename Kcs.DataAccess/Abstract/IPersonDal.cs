using Kcs.Core.DataAccess;
using Kcs.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kcs.DataAccess.Abstract
{
    public interface IPersonDal : IEntityRepository<Person>
    {
        //Custom Operatins
        void ResetPassword(Person person);
        Person LoginPerson(string email, string password);
        Person GetPersonWithMail(string email);
    }
}
