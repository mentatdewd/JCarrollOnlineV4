using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace jcarrollonlinev4.backend.Entities
{
    public class JCarrollOnlineV4DbContext : DbContext, IJCarrollOnlineDbContext
    {
        public JCarrollOnlineV4DbContext(DbContextOptions<JCarrollOnlineV4DbContext> context) : base(context)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=jcarrollonlinev4",
                    providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>();

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