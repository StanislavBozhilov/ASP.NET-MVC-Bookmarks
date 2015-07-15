namespace Bookmarks.Web.Controllers
{
    using System.Web.Mvc;

    using Bookmarks.Data;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        protected AdminController(IBookmarksData data)
            : base(data)
        {
        }
    }
}