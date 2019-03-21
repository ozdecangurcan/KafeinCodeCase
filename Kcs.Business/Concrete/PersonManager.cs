using Kcs.Business.Abstract;
using Kcs.DataAccess.Abstract;
using Kcs.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kcs.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public void Add(Person person)
        {
            _personDal.Add(person);
        }

        public Person GetPerson(int personId)
        {
            return _personDal.Get(p => p.PersonId == personId);
        }

        public Person GetPersonWithEmail(string email)
        {
            return _personDal.GetPersonWithMail(email);
        }

        public Person LoginPerson(string email, string password)
        {
            return _personDal.Get(x => x.PersonEmail == email && x.Password == password);
        }

        public void ResetPassword(Person person)
        {
            _personDal.ResetPassword(person);
        }

        public void Update(Person person)
        {
            _personDal.Update(person);
        }
    }
}
