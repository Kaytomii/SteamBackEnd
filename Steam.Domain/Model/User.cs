using Steam.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam.Domain.Model;

public class User : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    public string Username { get; set; } = null!;

    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("password_hash")]
    public string PasswordHash { get; set; } = null!;

    [Column("avatar_id")]
    public int? AvatarId { get; set; }
    [ForeignKey(nameof(AvatarId))]
    public Media? Avatar { get; set; }

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("role")]
    public UserRole Role { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("is_verified")]

    public bool IsVerified { get; set; } = false;

    public ICollection<RefreshToken> RefreshTokens { get; set; }
      = [];

    public ICollection<UserAchievement> UserAchievements { get; set; } = [];

    public ICollection<UserGame> UserGames { get; set; } = [];

    public ICollection<Game> DevelopedGames { get; set; } = [];

    public ICollection<UserFriend> Friends { get; set; } = [];
    public ICollection<UserFriend> FriendOf { get; set; } = [];
    public ICollection<UserProvider> UserProviders { get; set; } = [];
}