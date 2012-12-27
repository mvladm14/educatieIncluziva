using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EduIncluziva.Models.Mapping
{
    public class AdministratoriMap : EntityTypeConfiguration<Administratori>
    {
        public AdministratoriMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Username, t.Parola, t.Admin_ID });

            // Properties
            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Parola)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Administratori");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Parola).HasColumnName("Parola");
            this.Property(t => t.Admin_ID).HasColumnName("Admin_ID");
        }
    }
}
