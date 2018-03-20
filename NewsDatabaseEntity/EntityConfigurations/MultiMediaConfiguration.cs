using System.Data.Entity.ModelConfiguration;

namespace NewsDatabaseEntity.EntityConfigurations
{
    public class MultiMediaConfiguration : EntityTypeConfiguration<MultiMedia>
    {
        public MultiMediaConfiguration()
        {
            Property(m => m.Name)
                .IsRequired()
                .IsMaxLength();

            Property(m => m.FilePath)
                .IsRequired()
                .IsMaxLength();

            Property(m => m.FileType)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}