﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Models
{
    public class AuthorsViewModel
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<CheckBoxViewModel> Books { get; set; }
    }
}
