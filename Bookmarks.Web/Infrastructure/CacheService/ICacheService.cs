namespace Bookmarks.Web.Infrastructure.CacheService
{
    using System.Collections.Generic;

    using Bookmarks.Web.ViewModels;

    public interface ICacheService
    {
        IList<BookmarkViewModel> Bookmarks { get; }
    }
}
