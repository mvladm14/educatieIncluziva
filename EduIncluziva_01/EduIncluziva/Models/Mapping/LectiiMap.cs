using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EduIncluziva.Models.Mapping
{
    public class LectiiMap : EntityTypeConfiguration<Lectii>
    {
        public LectiiMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_Lectie);

            // Properties
            this.Property(t => t.Titlu)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ID_Lectie)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Lectii");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.ProfessorId).HasColumnName("ProfessorId");
            this.Property(t => t.Titlu).HasColumnName("Titlu");
            this.Property(t => t.ID_Lectie).HasColumnName("ID_Lectie");

            // Relationships
            this.HasRequired(t => t.Profesori)
                .WithMany(t => t.Lectiis)
                .HasForeignKey(d => d.ProfessorId);

        }
    }
}
