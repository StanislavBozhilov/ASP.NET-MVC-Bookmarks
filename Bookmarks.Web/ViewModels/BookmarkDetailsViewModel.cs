namespace Bookmarks.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Bookmarks.Models;

    using VGGLinkedIn.Common.Mappings;

    public class BookmarkDetailsViewModel : IMapFrom<Bookmark>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int? VotesCount { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Bookmark, BookmarkDetailsViewModel>()
                .ForMember(x => x.VotesCount, cnf => cnf.MapFrom(x => x.Votes.Sum(v => v.Value)));
        }
    }
}