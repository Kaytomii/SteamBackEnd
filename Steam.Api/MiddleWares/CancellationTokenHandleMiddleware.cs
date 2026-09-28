namespace Steam.Api.MiddleWares;

public class CancellationTokenHandleMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CancellationTokenHandleMiddleware> _logger;

    public CancellationTokenHandleMiddleware(RequestDelegate next, ILogger<CancellationTokenHandleMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Request was cancelled: {Path}", context.Request.Path);
            context.Response.StatusCode = StatusCodes.Status499ClientClosedRequest;
        }
    }
}