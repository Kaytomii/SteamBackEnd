using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.MediaDTOs;

public class MediaCreateDTO
{
    public Guid GameId { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}