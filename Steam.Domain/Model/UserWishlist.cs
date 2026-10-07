using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Steam.Domain.Model;

public class UserWishlist
{
    [Column("user_id")]
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    [Column("game_id")]
    public int GameId { get; set; }
    [ForeignKey("GameId")]
    public Game Game { get; set; } = null!;
}
