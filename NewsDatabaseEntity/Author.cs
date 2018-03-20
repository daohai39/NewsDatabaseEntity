using System;
using System.Collections;
using System.Collections.Generic;

namespace NewsDatabaseEntity
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
        public Cover Cover { get; set; }
        public int CoverId { get; set; }

        public ICollection<News> News { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Author()
        {
            News = new HashSet<News>();
        }
    }
}