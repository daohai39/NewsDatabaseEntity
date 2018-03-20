using System;

namespace NewsDatabaseEntity
{
    public class MultiMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string FilePath { get; set; }
        public double FileSize { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
    }
}