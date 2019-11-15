using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Milestone1.Controllers;
using Milestone1.Utilities;

namespace Milestone1.Models
{
    public class User : IValidatableObject
    {
        [Key]
        public int userID { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        [Required]
        [ValidEmailDomainAttribute(allowedDomain:"iitu.kz", ErrorMessage = "Email domain must be @iitu.kz")]
        [Remote(action: "IsEmailInUseAsync", controller: "User")]
        public string EmpCode { get; set; }

        public static explicit operator User(Task<User> v)
        {
            throw new NotImplementedException();
        }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string About { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int wordCount = 1;

            for (int i = 0; i < FullName.Length; i++)
            {
                if (FullName[i] == ' ')
                    wordCount++;
            }
            if (wordCount != 2)
                yield return new ValidationResult("Input 'Name' must have last name and first name");
        }

    
    }
}
