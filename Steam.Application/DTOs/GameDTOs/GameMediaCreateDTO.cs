using Steam.Domain.Enum;

namespace Steam.Application.DTOs.GameDTOs;

public class GameMediaCreateDTO
{
    public string Url { get; set; } = string.Empty;
    public MediaType Type { get; set; }
    public string FileName { get; set; } = string.Empty;
    public long Size { get; set; }
}