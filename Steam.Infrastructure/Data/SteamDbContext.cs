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
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<UserProvider> UserProviders { get; set; }


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

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(x => x.Avatar)
                    .WithMany(x => x.AvatarUsers)
                    .HasForeignKey(x => x.AvatarId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasIndex(x => x.Username).IsUnique();
                entity.HasIndex(x => x.Email).IsUnique();
            });
            modelBuilder.Entity<UserProvider>(entity =>
            {
                entity.HasIndex(userProvider => new { userProvider.UserId, userProvider.ProviderId }).IsUnique();
                entity.HasIndex(userProvider => new { userProvider.ProviderId, userProvider.NumberProvider }).IsUnique();

                entity.HasOne(userProvider => userProvider.User)
                      .WithMany(user => user.UserProviders)
                      .HasForeignKey(userProvider => userProvider.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(userProvider => userProvider.Provider)
                      .WithMany(provider => provider.UserProviders)
                      .HasForeignKey(userProvider => userProvider.ProviderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(genre => genre.Name).IsUnique();
                entity.HasData(
                    new Genre { Id = 1, Name = "Action" },
                    new Genre { Id = 2, Name = "Adventure" },
                    new Genre { Id = 3, Name = "RPG" },
                    new Genre { Id = 4, Name = "Strategy" },
                    new Genre { Id = 5, Name = "Simulation" },
                    new Genre { Id = 6, Name = "Sports" },
                    new Genre { Id = 7, Name = "Puzzle" },
                    new Genre { Id = 8, Name = "Racing" });
            });
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(tag => tag.Name).IsUnique();
                entity.HasData(
                    new Tag { Id = 1, Name = "Multiplayer" },
                    new Tag { Id = 2, Name = "Singleplayer" },
                    new Tag { Id = 3, Name = "Co-op" },
                    new Tag { Id = 4, Name = "Open World" },
                    new Tag { Id = 5, Name = "Story Rich" },
                    new Tag { Id = 6, Name = "Indie" },
                    new Tag { Id = 7, Name = "VR" },
                    new Tag { Id = 8, Name = "Early Access" });
            });
            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasIndex(provider => provider.Name).IsUnique();
                entity.HasData(
                    new Provider { Id = 1, Name = "Google" },
                    new Provider { Id = 2, Name = "Facebook" },
                    new Provider { Id = 3, Name = "Apple" });
            });
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(x => x.Price).HasColumnType("decimal(18,2)");
                entity.HasOne(x => x.Developer)
                    .WithMany(x => x.DevelopedGames)
                    .HasForeignKey(x => x.DeveloperId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasIndex(x => x.Token).IsUnique();
                entity.HasOne(x => x.User)
                    .WithMany(x => x.RefreshTokens)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasOne(x => x.Game)
                    .WithMany(x => x.Media)
                    .HasForeignKey(x => x.GameId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasOne(x => x.Game)
                    .WithMany(x => x.Achievements)
                    .HasForeignKey(x => x.GameId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(x => x.Icon)
                    .WithMany(x => x.AchievementIcons)
                    .HasForeignKey(x => x.IconId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<SystemRequirements>(entity =>
            {
                entity.HasOne(x => x.Game)
                    .WithMany(x => x.SystemRequirements)
                    .HasForeignKey(x => x.GameId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<GameTag>(entity =>
            {
                entity.HasKey(x => new { x.GameId, x.TagId });
                entity.HasOne(x => x.Game).WithMany(x => x.GameTags).HasForeignKey(x => x.GameId);
                entity.HasOne(x => x.Tag).WithMany(x => x.GameTags).HasForeignKey(x => x.TagId);
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.HasKey(x => new { x.GameId, x.GenreId });
                entity.HasOne(x => x.Game).WithMany(x => x.GameGenres).HasForeignKey(x => x.GameId);
                entity.HasOne(x => x.Genre).WithMany(x => x.GameGenres).HasForeignKey(x => x.GenreId);
            });

            modelBuilder.Entity<UserAchievement>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.AchievementId });
                entity.HasOne(x => x.User).WithMany(x => x.UserAchievements).HasForeignKey(x => x.UserId);
                entity.HasOne(x => x.Achievement).WithMany(x => x.UserAchievements).HasForeignKey(x => x.AchievementId);
            });

            modelBuilder.Entity<UserGame>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.GameId });
                entity.HasOne(x => x.User).WithMany(x => x.UserGames).HasForeignKey(x => x.UserId);
                entity.HasOne(x => x.Game).WithMany(x => x.UserGames).HasForeignKey(x => x.GameId);
            });
            modelBuilder.Entity<UserFriend>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.FriendId });
                entity.HasOne(x => x.User).WithMany(x => x.Friends).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Friend).WithMany(x => x.FriendOf).HasForeignKey(x => x.FriendId).OnDelete(DeleteBehavior.Restrict);
                entity.HasCheckConstraint("CK_UserFrends_NoSelfFriendship", "[user_id] <> [friend_id]");
            });
        }
    }
}