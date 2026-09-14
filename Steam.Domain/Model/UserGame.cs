using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam.Domain.Model;

public class UserGame
{
    [Column("user_id")]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    [Column("achievement_id")]
    public int AchievementId { get; set; }
    [ForeignKey("AchievementId")]
    public Achievement Achievement { get; set; } = null!;
    [Column("purchased_at")]
    public DateTime PurchasedAt { get; set; }
    [Column("playtime")]
    public int Playtime { get; set; }
}
