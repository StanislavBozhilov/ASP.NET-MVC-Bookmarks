namespace Bookmarks.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int BookmarkId { get; set; }

        public Bookmark Bookmark { get; set; }
    }
}
