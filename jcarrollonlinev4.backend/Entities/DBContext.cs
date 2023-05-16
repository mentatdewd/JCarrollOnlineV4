using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace webapi.Entities
{
    public class webapiConnection : DbContext, IwebapiContext
    {
        public webapiConnection(DbContextOptions<webapiConnection> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasKey(m => m);

            modelBuilder.Entity<Micropost>();

            modelBuilder.Entity<BlogItem>();

            modelBuilder.Entity<Forum>();

            modelBuilder.Entity<ForumModerator>();

            modelBuilder.Entity<ThreadEntry>();


            modelBuilder.Entity<Entities.NLog>();
        }
        public virtual DbSet<IdentityRole> IdentityRole { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Forum> Forum { get; set; }
        public DbSet<ForumModerator> ForumModerator { get; set; }
        public DbSet<ThreadEntry> ForumThreadEntry { get; set; }
        public DbSet<Micropost> Micropost { get; set; }
        public DbSet<BlogItem> BlogItem { get; set; }
        public DbSet<BlogItemComment> BlogItemComment { get; set; }
        public DbSet<Entities.NLog> NLog { get; set; }
    }
}