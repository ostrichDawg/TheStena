namespace TheStena.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Upvotes { get; set; } = 0;
        public int Downvotes { get; set; } = 0;
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
