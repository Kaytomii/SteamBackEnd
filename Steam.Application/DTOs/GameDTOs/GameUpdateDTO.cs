using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.GameDTOs;

public class GameUpdateDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}