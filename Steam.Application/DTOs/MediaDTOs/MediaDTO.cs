using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.MediaDTOs;

public class MediaDTO
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}
