namespace Bookmarks.Data
{
    using System.Data.Entity;

    using Bookmarks.Models;

    public interface IBookmarksDbContext
    {
        IDbSet<Bookmark> Bookmarks { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Vote> Votes { get; set; }

        int SaveChanges();
    }
}
