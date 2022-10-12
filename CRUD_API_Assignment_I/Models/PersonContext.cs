using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API_Assignment_I.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext>options) : base(options)
        {

        }
        public DbSet<Persons> Persons_Shuba { get; set; }
    }
}


