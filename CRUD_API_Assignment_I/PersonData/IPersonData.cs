using CRUD_API_Assignment_I.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API_Assignment_I.PersonData
{
    public interface IPersonData
    {
        List<Persons> GetPersons();
        Persons GetPerson(Guid id);
        Persons AddPerson(Persons person);
        Persons EditPersons(Persons person);
        void DeletePersons(Persons person);
    }
}
