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

    [Column("avatar")]
    public Media Avatar { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("role")]
    public UserRole Role { get; set; }

    public ICollection<UserAchievement> UserAchievements { get; set; } = [];

    public ICollection<UserGame> UserGames { get; set; } = [];
}
