using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<AuthorToBook> AuthorToBooks { get; set; }

    }
}
