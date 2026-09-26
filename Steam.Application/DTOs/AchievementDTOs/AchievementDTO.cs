using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.AchievementDTOs;

public class AchievementDTO
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? IconId { get; set; }
}