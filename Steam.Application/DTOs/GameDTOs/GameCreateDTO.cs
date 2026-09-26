using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.GameDTOs;

public class GameCreateDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public IEnumerable<int> GenreIds { get; set; } = Array.Empty<int>();
    public IEnumerable<int> TagIds { get; set; } = Array.Empty<int>();
}