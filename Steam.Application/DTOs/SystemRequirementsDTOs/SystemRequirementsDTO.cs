using Steam.Domain.Enum;

namespace Steam.Application.DTOs.SystemRequirementsDTOs;

public class SystemRequirementsDTO
{
    public Guid Id { get; set; }
    public Guid GameId { get; set; }
    public SystemRequirementsType Type { get; set; }
    public string? Os { get; set; }
    public string? Cpu { get; set; }
    public string? Gpu { get; set; }
    public string? Ram { get; set; }
    public string? Storage { get; set; }
    public string? DirectX { get; set; }
    public string? AdditionalNotes { get; set; }
}
