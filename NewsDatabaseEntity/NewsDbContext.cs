using System.Data.Entity;
using NewsDatabaseEntity.EntityConfigurations;

namespace NewsDatabaseEntity
{
    public class NewsDbContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<MultiMedia> MultiMedias { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cover> Covers { get; set; }

        public NewsDbContext()
            : base()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new NewsConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new MultiMediaConfiguration());
            modelBuilder.Configurations.Add(new CoverConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}