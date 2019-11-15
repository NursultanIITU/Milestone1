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
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
       
        public string MobileNo { get; set; }
     
        //[PosNumberAttribute(ErrorMessage = "need a positive number, bigger than 0")]
        public int salary { get; set; }

        public virtual Address Address { get; set; }
    }
}
