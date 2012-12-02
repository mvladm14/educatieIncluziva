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

        public DbSet<Elevi> Elevis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EleviMap());
        }
    }
}
