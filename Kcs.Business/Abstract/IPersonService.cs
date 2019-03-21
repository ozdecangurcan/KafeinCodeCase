using Kcs.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kcs.Business.Abstract
{
    public interface IPersonService
    {
        Person GetPerson(int personId);
        void Add(Person person);
        void Update(Person person);
        Person LoginPerson(string email, string password);
        void ResetPassword(Person person);
        Person GetPersonWithEmail(string email);
    }
}
