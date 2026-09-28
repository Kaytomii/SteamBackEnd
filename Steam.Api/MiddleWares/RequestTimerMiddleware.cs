using System.Diagnostics;

namespace Steam.Api.MiddleWares;

public class RequestTimerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimerMiddleware> _logger;

    public RequestTimerMiddleware(RequestDelegate next, ILogger<RequestTimerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        await _next(context);

        stopwatch.Stop();
        _logger.LogInformation("Request [{Method}] {Path} executed in {Elapsed} ms",
            context.Request.Method,
            context.Request.Path,
            stopwatch.ElapsedMilliseconds);
    }
}