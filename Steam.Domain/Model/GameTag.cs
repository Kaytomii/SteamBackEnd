
using System.ComponentModel.DataAnnotations.Schema;

namespace Steam.Domain.Model;

public class GameTag
{

    [Column("game_id")]
    public int GameId { get; set; }
    [ForeignKey("GameId")]
    public Game Game { get; set; } = null!;
    [Column("tag_id")]
    public int TagId { get; set; }
    [ForeignKey("TagId")]
    public Tag Tag { get; set; } = null!;
}
