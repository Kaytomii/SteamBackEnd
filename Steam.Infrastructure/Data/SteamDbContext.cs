using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Data
{
    public class SteamDbContext : DbContext
    {
        public SteamDbContext(DbContextOptions<SteamDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<GameTag> GameTags { get; set; }
        public DbSet<SystemRequirements> SystemRequirements { get; set; }
        public DbSet<Media> Medias { get; set; }


        public override int SaveChanges()
        {
            SetTimestamps();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void SetTimestamps()
        {
            var now = DateTime.UtcNow;

            foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameTag>()
                .HasKey(x => new { x.GameId, x.TagId });
            modelBuilder.Entity<GameGenre>()
                .HasKey(x => new { x.GameId, x.GenreId });
            modelBuilder.Entity<UserAchievement>()
                .HasKey(x => new { x.UserId, x.AchievementId });
            modelBuilder.Entity<UserGame>()
                .HasKey(x => new { x.UserId, x.GameId });

        }
    }
}
