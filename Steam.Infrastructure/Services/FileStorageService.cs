using Microsoft.AspNetCore.Hosting;
using Steam.Application.Interfaces.Services;

namespace Steam.Infrastructure.Services;

public class FileStorageService : IFileStorageService
{
    private readonly IWebHostEnvironment _environment;

    public FileStorageService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> SaveAsync(
        Stream content,
        string fileName,
        CancellationToken ct)
    {
        var directory = Path.Combine(
            _environment.WebRootPath ?? Path.Combine(_environment.ContentRootPath, "wwwroot"),
            "uploads",
            "games");

        Directory.CreateDirectory(directory);

        var path = Path.Combine(directory, fileName);

        await using var output = new FileStream(
            path,
            FileMode.CreateNew,
            FileAccess.Write,
            FileShare.None);

        await content.CopyToAsync(output, ct);

        return $"/uploads/games/{fileName}";
    }

    public Task DeleteAsync(string fileName, CancellationToken ct)
    {
        var directory = Path.Combine(
            _environment.WebRootPath ?? Path.Combine(_environment.ContentRootPath, "wwwroot"),
            "uploads",
            "games");

        var path = Path.Combine(directory, fileName);

        if (File.Exists(path))
            File.Delete(path);

        return Task.CompletedTask;
    }
}
