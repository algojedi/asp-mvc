using Classrooms.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms.Data
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Person> Persons { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
