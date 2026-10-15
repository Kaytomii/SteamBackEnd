using Steam.Domain.Enum;

namespace Steam.Application.DTOs.MediaDTOs;

public class MediaCreateDTO
{
    public Guid? GameId { get; set; }
    public string? Url { get; set; }
    public MediaType Type { get; set; }
    public string? FileName { get; set; }
    public long? Size { get; set; }
}