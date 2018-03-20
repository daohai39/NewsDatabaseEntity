using System;
using System.Collections;
using System.Collections.Generic;

namespace NewsDatabaseEntity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<News> News { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Category()
        {
            News = new HashSet<News>();
        }
    }
}