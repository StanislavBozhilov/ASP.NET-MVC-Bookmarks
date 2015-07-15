namespace VGGLinkedIn.Web.Infrastructure.CacheService
{
    using System.Collections.Generic;

    using VGGLinkedIn.Web.ViewModels;

    public interface ICacheService
    {
        IList<GroupViewModel> Groups { get; }
    }
}
