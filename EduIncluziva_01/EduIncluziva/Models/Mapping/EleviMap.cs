using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EduIncluziva.Models.Mapping
{
    public class EleviMap : EntityTypeConfiguration<Elevi>
    {
        public EleviMap()
        {
            // Primary Key
            this.HasKey(t => t.Elev_ID);

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

            // Table & Column Mappings
            this.ToTable("Elevi");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Nume).HasColumnName("Nume");
            this.Property(t => t.Prenume).HasColumnName("Prenume");
            this.Property(t => t.Elev_ID).HasColumnName("Elev_ID");
            this.Property(t => t.Parola).HasColumnName("Parola");
        }
    }
}
