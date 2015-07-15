namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bookmarks.Data;
    using Bookmarks.Web.Infrastructure.CacheService;
    using Bookmarks.Web.ViewModels;

    public class HomeController : BaseController
    {
        private ICacheService cacheService;

        public HomeController(IBookmarksData data, ICacheService cacheService)
            : base(data)
        {
            this.cacheService = cacheService;
        }

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel { Bookmarks = this.cacheService.Bookmarks };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}