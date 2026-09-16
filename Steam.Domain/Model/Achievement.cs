using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Steam.Domain.Model;

public class Achievement : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("icon")]
    public Media Icon { get; set; }
    [Column("game_id")]
    public int GameId { get; set; }
    [ForeignKey("GameId")]
    public Game Game { get; set; } = null!;
    
}
