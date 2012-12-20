using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EduIncluziva.Models.Mapping
{
    public class LiceeMap : EntityTypeConfiguration<Licee>
    {
        public LiceeMap()
        {
            // Primary Key
            this.HasKey(t => t.Liceu_ID);

            // Properties
            this.Property(t => t.Nume)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Licee");
            this.Property(t => t.Nume).HasColumnName("Nume");
            this.Property(t => t.Liceu_ID).HasColumnName("Liceu_ID");
            this.Property(t => t.Profesor_ID).HasColumnName("Profesor_ID");

            // Relationships
            this.HasRequired(t => t.Profesori)
                .WithMany(t => t.Licees)
                .HasForeignKey(d => d.Profesor_ID);

        }
    }
}
