using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookmarks.Web.InputModels
{
    using Bookmarks.Models;

    using VGGLinkedIn.Common.Mappings;

    public class CommentInputModel : IMapTo<Comment>
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public int BookmarkId { get; set; }
    }
}