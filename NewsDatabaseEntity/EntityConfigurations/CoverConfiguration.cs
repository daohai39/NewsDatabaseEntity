using System.Data.Entity.ModelConfiguration;

namespace NewsDatabaseEntity.EntityConfigurations
{
    public class CoverConfiguration : EntityTypeConfiguration<Cover>
    {
        public CoverConfiguration()
        {
            Property(c => c.Path)
                .IsRequired()
                .IsMaxLength();
        }
    }
}