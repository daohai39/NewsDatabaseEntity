using System;
using System.Collections.Generic;

namespace NewsDatabaseEntity
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<MultiMedia> MultiMedias { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public byte Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public News()
        {
            MultiMedias = new HashSet<MultiMedia>();
            Tags = new HashSet<Tag>();
        }
    }
}