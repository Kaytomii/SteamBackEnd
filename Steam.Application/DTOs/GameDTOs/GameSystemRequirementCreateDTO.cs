using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.GameDTOs;

public class GameSystemRequirementCreateDTO
{
    public string Os { get; set; } = string.Empty;
    public string Cpu { get; set; } = string.Empty;
    public string Gpu { get; set; } = string.Empty;
    public string Ram { get; set; } = string.Empty;
    public string Storage { get; set; } = string.Empty;
}
