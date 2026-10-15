using Microsoft.AspNetCore.Http;
namespace Steam.Api.Models;

public class GameCreateForm
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid DeveloperId { get; set; }

    public string GenreIds { get; set; } = "[]";
    public string TagIds { get; set; } = "[]";
    public string SystemRequirements { get; set; } = "[]";
    public string Achievements { get; set; } = "[]";

    public List<string> MediaTypes { get; set; } = [];
    public List<IFormFile> MediaFiles { get; set; } = [];
}
