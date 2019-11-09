using Microsoft.EntityFrameworkCore;
using Milestone1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorToBook> AuthorsToBooks { get; set; }
        public DbSet<Employee> Employees  { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
