namespace Lab3.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublishedYear { get; set; }
        public string Isbn { get; set; }
    }
}
