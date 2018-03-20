using System.Data.Entity.ModelConfiguration;

namespace NewsDatabaseEntity.EntityConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}