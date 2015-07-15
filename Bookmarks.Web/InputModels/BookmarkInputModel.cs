namespace Bookmarks.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Bookmarks.Models;

    using VGGLinkedIn.Common.Mappings;

    public class BookmarkInputModel : IMapTo<Bookmark>
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "The {0} is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The {0} should be between {2} and {1}.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]
        [Url(ErrorMessage = "The {0} is invalid.")]
        public string Url { get; set; }

        public string Description { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}