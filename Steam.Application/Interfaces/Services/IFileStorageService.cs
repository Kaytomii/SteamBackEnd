using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IFileStorageService
{
    Task<string> SaveAsync(
        Stream content,
        string fileName,
        CancellationToken ct);

    Task DeleteAsync(
        string fileName,
        CancellationToken ct);
}