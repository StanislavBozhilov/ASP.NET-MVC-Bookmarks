namespace Bookmarks.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }
    }
}
