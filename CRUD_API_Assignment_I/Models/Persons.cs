using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API_Assignment_I.Models
{
    public class Persons
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string First_Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Last_Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

    }
}