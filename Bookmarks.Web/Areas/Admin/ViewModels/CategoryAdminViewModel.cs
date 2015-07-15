namespace Bookmarks.Web.Areas.Admin.ViewModels
{
    using Bookmarks.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using VGGLinkedIn.Common.Mappings;

    public class CategoryAdminViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
    }
}