using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookmarks.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bookmarks.Data;
    using Bookmarks.Models;
    using Bookmarks.Web.InputModels;
    using Bookmarks.Web.ViewModels;

    using Microsoft.AspNet.Identity;
        
    [Authorize]
    public class CommentsController : BaseController
    {
        public CommentsController(IBookmarksData data) : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                model.UserId = this.User.Identity.GetUserId();
                var comment = Mapper.Map<Comment>(model);
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentViewModel = this.Data.Comments
                    .All()
                    .Where(x => x.Id == comment.Id)
                    .Project()
                    .To<CommentViewModel>()
                    .FirstOrDefault();
                return this.PartialView("DisplayTemplates/CommentViewModel", commentViewModel);
            }

            return this.Json(this.ModelState);
        }
    }
}