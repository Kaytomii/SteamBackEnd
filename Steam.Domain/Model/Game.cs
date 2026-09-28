using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam.Domain.Model;

public class Game : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("price")]
    public decimal Price { get; set; }
    
    [Column("developer_id")]
    public Guid DeveloperId { get; set; }
    [ForeignKey("DeveloperId")]
    public User Developer { get; set; } = null!;

    [Column("release_date")]
    public DateTime ReleaseDate { get; set; }

    public ICollection<Achievement> Achievements { get; set; } = [];

    public ICollection<GameTag> GameTags { get; set; } = [];

    public ICollection<GameGenre> GameGenres { get; set; } = [];

    public ICollection<SystemRequirements> SystemRequirements { get; set; } = [];

    public ICollection<UserGame> UserGames { get; set; } = [];

    public ICollection<Media> Media { get; set; } = [];
}