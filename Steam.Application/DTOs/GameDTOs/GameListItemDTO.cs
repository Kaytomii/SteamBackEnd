using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.GameDTOs;

public class GameListItemDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
}