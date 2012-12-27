using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EduIncluziva.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => new { t.User_ID, t.Role });

            // Properties
            this.Property(t => t.Role)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.User_ID).HasColumnName("User_ID");
            this.Property(t => t.Role).HasColumnName("Role");
        }
    }
}
