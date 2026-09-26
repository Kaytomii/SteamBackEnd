using System.ComponentModel.DataAnnotations.Schema;

namespace Steam.Domain.Model;

public class UserAchievement
{
    [Column("user_id")]
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    [Column("achievement_id")]
    public int AchievementId { get; set; }
    [ForeignKey("AchievementId")]
    public Achievement Achievement { get; set; } = null!;
    [Column("unlocked_at")]
    public DateTime UnlockedAt { get; set; }
}
