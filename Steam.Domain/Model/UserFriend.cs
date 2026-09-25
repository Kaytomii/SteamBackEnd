using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam.Domain.Model;

public class UserFriend
{
    [Column("user_id")]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    [Column("friend_id")]
    public int FriendId { get; set; }
    [ForeignKey("FriendId")]
    public User Friend { get; set; } = null!;
}
