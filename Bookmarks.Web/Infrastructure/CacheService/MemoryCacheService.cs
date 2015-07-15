namespace Bookmarks.Web.Infrastructure.CacheService
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using Bookmarks.Data;
    using Bookmarks.Web.ViewModels;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly IBookmarksData data;

        public MemoryCacheService(IBookmarksData data)
        {
            this.data = data;
        }

        public IList<BookmarkViewModel> Bookmarks
        {
            get
            {
                return this.Get<IList<BookmarkViewModel>>("Bookmarks", () =>
                    this.data.Bookmarks
                        .All()
                        .OrderByDescending(x => x.Votes.Sum(v => v.Value))
                        .Take(6)
                        .Project()
                        .To<BookmarkViewModel>()
                        .ToList());
            }
        }
    }
}