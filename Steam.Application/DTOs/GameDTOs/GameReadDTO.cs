using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.GameDTOs;

public class GameReadDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DeveloperId { get; set; }
    public ICollection<int>? Achievements { get; set; }
    public ICollection<int>? GameTags { get; set; }
    public ICollection<int>? GameGenres { get; set; }
    public ICollection<int>? SystemRequirements { get; set; }

}
