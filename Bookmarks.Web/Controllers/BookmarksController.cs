namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bookmarks.Common.SystemMessages;
    using Bookmarks.Data;
    using Bookmarks.Models;
    using Bookmarks.Web.InputModels;
    using Bookmarks.Web.ViewModels;

    using Microsoft.AspNet.Identity;

    using PagedList;

    [Authorize]
    public class BookmarksController : BaseController
    {
        public BookmarksController(IBookmarksData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var bookmarks = this.Data.Bookmarks
                .All()
                .OrderBy(x => x.Title)
                .Project()
                .To<BookmarkViewModel>()
                .ToPagedList(page ?? 1, 6);
            return View(bookmarks);
        }

        public ActionResult Details(int id)
        {
            var bookmark = this.Data.Bookmarks
                .All()
                .Where(x => x.Id == id)
                .Project()
                .To<BookmarkDetailsViewModel>()
                .FirstOrDefault();
            return this.View(bookmark);
        }

        public ActionResult Create()
        {
            this.LoadCategories();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookmarkInputModel model)
        {
            if (model != null & this.ModelState.IsValid)
            {
                var bookmark = Mapper.Map<Bookmark>(model);
                this.Data.Bookmarks.Add(bookmark);
                this.Data.SaveChanges();

                this.AddSystemMessage(string.Format("Bookmark {0} added.", bookmark.Title), SystemMessageType.Success);
                return this.RedirectToAction("Details", new { id = bookmark.Id });
            }

            this.LoadCategories();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int id)
        {
            var bookmark = this.Data.Bookmarks.All().FirstOrDefault(x => x.Id == id);
            if (bookmark != null)
            {
                var userId = this.User.Identity.GetUserId();
                
                var vote = new Vote
                {
                    BookmarkId = id,
                    UserId = userId,
                    Value = 1
                };

                this.Data.Votes.Add(vote);
                this.Data.SaveChanges();

                var votesCount = bookmark.Votes.Sum(x => x.Value);
                return this.Json(votesCount, JsonRequestBehavior.AllowGet);
            }

            return this.Json("Error");
        }

        private void LoadCategories()
        {
            this.ViewBag.Categories = this.Data.Categories
                .All()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
        }
    }
}