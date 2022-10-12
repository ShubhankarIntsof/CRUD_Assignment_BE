using CRUD_API_Assignment_I.Models;
using CRUD_API_Assignment_I.PersonData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API_Assignment_I.Controllers
{
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonData _persons;
        public PersonController(IPersonData personData)
        {
            _persons = personData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPersons()
        {
            return Ok(_persons.GetPersons());
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddPersons(Persons persons)
        {
            if (persons!= null)
            {
                _persons.AddPerson(persons);
                return Ok(persons);
            }
            return NotFound("Person not valid.");
        }
        //Resolving +++++++++++++++++=====
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditPersons(Guid id , Persons persons)
        {
            //var ExistingPerson = _persons.GetPerson(id);
            if ( true )
            {
                persons.Id = id;
                //persons.Id = ExistingPerson.Id;
                _persons.EditPersons(persons);
                return Ok(persons);
            }
            //return NotFound("Person not Found.");
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPerson(Guid id)
        {
            var per = _persons.GetPerson(id);
            if (per != null)
            {
                return Ok(per);
            }
            return NotFound($"Person with {id} not found.");
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            var per = _persons.GetPerson(id);
            if (per != null)
            {
                _persons.DeletePersons(per);
                return Ok(per);
            }
            return NotFound($"Person with {id} not found.");

        }



    }
}
