namespace Bookmarks.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Security.Claims;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Bookmark> bookmarks;

        public User()
        {
            this.bookmarks = new HashSet<Bookmark>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<Bookmark> Bookmarks
        {
            get { return this.bookmarks; }
            set { this.bookmarks = value; }
        }
    }
}
