namespace VGGLinkedIn.Web.Infrastructure.CacheService
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using VGGLinkedIn.Data;
    using VGGLinkedIn.Web.ViewModels;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly IVggLinkedInData data;

        public MemoryCacheService(IVggLinkedInData data)
        {
            this.data = data;
        }

        public IList<GroupViewModel> Groups
        {
            get
            {
                return this.Get<IList<GroupViewModel>>("Groups", () => 
                    this.data.Groups.All()
                        .Project()
                        .To<GroupViewModel>()
                        .ToList());
            }
        }
    }
}