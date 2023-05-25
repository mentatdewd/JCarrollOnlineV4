using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace jcarrollonlinev4.backend.Entities
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<IdentityResult> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            IdentityResult identityResult = await manager.CreateAsync(this, "password").ConfigureAwait(false);
            // Add custom user claims here
            return identityResult;
        }


        public bool MicroPostEmailNotifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sms")]
        public bool MicroPostSmsNotifications { get; set; }

        // Navigation Property
        public virtual ICollection<ForumThreadEntry>? ForumThreadEntries { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public virtual ICollection<Micropost>? Microposts { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public virtual ICollection<ApplicationUser>? Following { get; private set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public virtual ICollection<ApplicationUser>? Followers { get; private set; }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IContext
    //{
    //    public ApplicationDbContext(string nameOrConnectionString)
    //        : base(nameOrConnectionString)
    //    {
    //    }
        
    //    public ApplicationDbContext()
    //        : base("JCarrollOnlineV2Connection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}