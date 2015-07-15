namespace Bookmarks.Web.ViewModels
{
    using Bookmarks.Models;

    using VGGLinkedIn.Common.Mappings;

    public class BookmarkViewModel : IMapFrom<Bookmark>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }
}
