using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EduIncluziva.Models.Mapping
{
    public class LectiiMap : EntityTypeConfiguration<Lectii>
    {
        public LectiiMap()
        {
            // Primary Key
            this.HasKey(t => t.Lectie_ID);

            // Properties
            this.Property(t => t.Titlu)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.URL)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Lectii");
            this.Property(t => t.Profesor_ID).HasColumnName("Profesor_ID");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Titlu).HasColumnName("Titlu");
            this.Property(t => t.Lectie_ID).HasColumnName("Lectie_ID");
            this.Property(t => t.URL).HasColumnName("URL");

            // Relationships
            this.HasRequired(t => t.Profesori)
                .WithMany(t => t.Lectiis)
                .HasForeignKey(d => d.Profesor_ID); 

        }
    }
}
