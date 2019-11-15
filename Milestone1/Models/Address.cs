using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Models
{
    public class Address 
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

    
        public string AddressLine1 { get; set; }

 
        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Pincode { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
