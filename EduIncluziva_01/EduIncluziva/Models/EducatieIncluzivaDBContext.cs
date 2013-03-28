using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EduIncluziva.Models
{
    public class EducatieIncluzivaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<HighSchool> HighSchools { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}
