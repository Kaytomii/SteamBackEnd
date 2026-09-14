using Steam.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Steam.Domain.Model;

public class SystemRequirements : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("game_id")]
    public int GameId { get; set; }
    [ForeignKey("GameId")]
    public Game Game { get; set; } = null!;
    [Column("type")]
    public SystemRequirementsType Type { get; set; }
    [Column("os")]
    public string OS { get; set; }
    [Column("processor")]
    public string Processor { get; set; }
    [Column("memory")]
    public string Memory { get; set; }
    [Column("graphics")]
    public string Graphics { get; set; }
    [Column("directx")]
    public string DirectX { get; set; }
    [Column("storage")]
    public string Storage { get; set; }
    [Column("additional_notes")]
    public string AdditionalNotes { get; set; }
}
