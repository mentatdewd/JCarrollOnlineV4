using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace jcarrollonlinev4.backend.Entities
{
    public interface IJCarrollOnlineDbContext
    {
        DbSet<IdentityRole> IdentityRole { get; set; }
        DbSet<ApplicationUser> ApplicationUser { get; set; }
        //DbSet<IdentityUserClaim> IdentityUserClaim { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
        //DbSet<IdentityUserLogin> IdentityUserLogin { get; set; }
        //DbSet<IdentityUserRole> IdentityUserRole { get; set; }

        DbSet<Forum> Forum { get; set; }

        DbSet<ForumModerator> ForumModerator { get; set; }

        DbSet<ForumThreadEntry> ForumThreadEntry { get; set; }

        DbSet<Micropost> Micropost { get; set; }

        DbSet<BlogItem> BlogItem { get; set; }
        DbSet<BlogItemComment> BlogItemComment { get; set; }
        DbSet<NLog> NLog { get; set; }

        int SaveChanges();
        //Task<int> SaveChangesAsync();
        //DbEntityEntry Entry(object entity);
    }
}
