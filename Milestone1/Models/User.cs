using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string EmpCode { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string About { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
