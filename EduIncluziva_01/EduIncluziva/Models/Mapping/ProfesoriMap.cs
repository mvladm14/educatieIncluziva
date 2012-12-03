using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EduIncluziva.Models.Mapping
{
    public class ProfesoriMap : EntityTypeConfiguration<Profesori>
    {
        public ProfesoriMap()
        {
            // Primary Key
            this.HasKey(t => t.Profesor_ID);

            // Properties
            this.Property(t => t.Mail)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Nume)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Prenume)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Parola)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Bio)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Profesori");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Nume).HasColumnName("Nume");
            this.Property(t => t.Prenume).HasColumnName("Prenume");
            this.Property(t => t.Parola).HasColumnName("Parola");
            this.Property(t => t.Poza).HasColumnName("Poza");
            this.Property(t => t.Bio).HasColumnName("Bio");
            this.Property(t => t.Profesor_ID).HasColumnName("Profesor_ID");
            this.Property(t => t.Liceu_ID).HasColumnName("Liceu_ID");

            // Relationships
            this.HasRequired(t => t.Licee)
                .WithMany(t => t.Profesoris)
                .HasForeignKey(d => d.Liceu_ID);

        }
    }
}
