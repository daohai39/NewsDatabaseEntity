namespace NewsDatabaseEntity
{
    public class Cover
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}