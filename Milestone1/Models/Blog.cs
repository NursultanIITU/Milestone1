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
        [Required, MaxLength(100, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required, MaxLength(250, ErrorMessage = "Content cannot exceed 250 characters")]
        public string Content { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required, MaxLength(150, ErrorMessage = "Image cannot exceed 100 characters")]
        public string Image { get; set; }

        public int userID { get; set; }

        public virtual User User { get; set; }
    }
}
