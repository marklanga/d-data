using System;
using System.ComponentModel.DataAnnotations;

namespace Dimension_Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }

    }
}
