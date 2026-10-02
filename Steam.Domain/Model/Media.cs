using Steam.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Steam.Domain.Model;

public class Media : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("url")]
    public string? Url { get; set; } = null!;

    [Column("type")]
    public MediaType Type { get; set; }

    [Column("file_name")]
    public string? FileName { get; set; } = null!;

    [Column("size")]
    public long? Size { get; set; }
    [Column("game_id")]
    public int? GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public Game? Game { get; set; }
    public ICollection<User> AvatarUsers { get; set; } = [];

    public ICollection<Achievement> AchievementIcons { get; set; } = [];
}