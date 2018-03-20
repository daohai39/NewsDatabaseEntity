using System.Data.Entity.ModelConfiguration;

namespace NewsDatabaseEntity.EntityConfigurations
{
    public class NewsConfiguration : EntityTypeConfiguration<News>
    {
        public NewsConfiguration()
        {
            Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(255);

            Property(n => n.Slug)
                .IsRequired()
                .HasMaxLength(255);

            Property(n => n.Content)
                .IsRequired()
                .HasMaxLength(2000);

            HasMany(n => n.MultiMedias)
                .WithRequired(m => m.News);

            HasRequired(n => n.Category)
                .WithMany(c => c.News)
                .HasForeignKey(n => n.CategoryId)
                .WillCascadeOnDelete(false);

            HasMany(n => n.Tags)
                .WithMany(t => t.News)
                .Map(m =>
                {
                    m.ToTable("NewsTags");
                    m.MapLeftKey("NewsId");
                    m.MapRightKey("TagId");
                });
        }
    }
}