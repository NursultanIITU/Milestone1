using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Models
{
    public class Blog
    {
        [Key]
        public int blogID { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Content { get; set; }

        public int userID { get; set; }

        public virtual User User { get; set; }
    }
}
