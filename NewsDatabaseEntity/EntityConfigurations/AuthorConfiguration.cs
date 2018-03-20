using System.Data.Entity.ModelConfiguration;

namespace NewsDatabaseEntity.EntityConfigurations
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);
            Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(255);
            Property(a => a.Address)
                .HasMaxLength(500);
            HasRequired(a => a.Cover)
                .WithRequiredPrincipal(c => c.Author);
            HasMany(a => a.News)
                .WithRequired(n => n.Author)
                .HasForeignKey(a => a.AuthorId)
                .WillCascadeOnDelete(false);
        }
    }
}