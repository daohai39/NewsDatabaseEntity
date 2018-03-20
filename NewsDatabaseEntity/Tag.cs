using System;
using System.Collections.Generic;

namespace NewsDatabaseEntity
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<News> News { get; set; }

        public Tag()
        {
            News = new HashSet<News>();
        }
    }
}