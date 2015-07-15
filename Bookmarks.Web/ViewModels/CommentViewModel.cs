namespace Bookmarks.Web.ViewModels
{
    using Bookmarks.Models;

    using VGGLinkedIn.Common.Mappings;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.Username, cfg => cfg.MapFrom(e => e.User.UserName));
        }
    }
}
