using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Milestone1.Utilities;

namespace Milestone1.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        //[PosNumberAttribute(ErrorMessage = "need a positive number, bigger than 0")]
        public int salary { get; set; }

        public virtual Address Address { get; set; }
    }
}
