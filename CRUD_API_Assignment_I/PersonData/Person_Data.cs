using CRUD_API_Assignment_I.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API_Assignment_I.PersonData
{
    public class Person_Data : IPersonData
    {
        private PersonContext _personContext;
        public Person_Data(PersonContext personContext)
        {
            _personContext = personContext;
        }
        public Persons AddPerson(Persons person)
        {
            person.Id = Guid.NewGuid();
            _personContext.Persons_Shuba.Add(person);
            _personContext.SaveChanges();
            return person;
            
        }

        public void DeletePersons(Persons person)
        {
            _personContext.Persons_Shuba.Remove(person);
            _personContext.SaveChanges();
        }

        public Persons EditPersons(Persons person)
        {
            _personContext.Persons_Shuba.Update(person);
            _personContext.SaveChanges();
            return person;
        }

        public Persons GetPerson(Guid id)
        {
            var per = _personContext.Persons_Shuba.SingleOrDefault(i => i.Id == id);
            return per;
            
        }

        public List<Persons> GetPersons()
        {
            return (_personContext.Persons_Shuba.ToList());
           
        }
    }
}
