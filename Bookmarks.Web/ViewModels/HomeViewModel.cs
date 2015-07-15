namespace Bookmarks.Web.ViewModels
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<BookmarkViewModel> Bookmarks { get; set; }
    }
}