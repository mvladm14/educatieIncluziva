using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EduIncluziva.Models.Mapping;

namespace EduIncluziva.Models
{
    public class EducatieIncluzivaDBContext : DbContext
    {
        static EducatieIncluzivaDBContext()
        {
            Database.SetInitializer<EducatieIncluzivaDBContext>(null);
        }

		public EducatieIncluzivaDBContext()
			: base("Name=EducatieIncluzivaDBContext")
		{
		}

        public DbSet<Administratori> Administratoris { get; set; }
        public DbSet<Elevi> Elevis { get; set; }
        public DbSet<Lectii> Lectiis { get; set; }
        public DbSet<Licee> Licees { get; set; }
        public DbSet<Profesori> Profesoris { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdministratoriMap());
            modelBuilder.Configurations.Add(new EleviMap());
            modelBuilder.Configurations.Add(new LectiiMap());
            modelBuilder.Configurations.Add(new LiceeMap());
            modelBuilder.Configurations.Add(new ProfesoriMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
