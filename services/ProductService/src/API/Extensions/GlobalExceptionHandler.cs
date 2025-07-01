using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IHostEnvironment _env;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Logging the exception with the details
            _logger.LogError(exception,
                "Unhandled exception occurred. Trace ID: {TraceId}",
                httpContext.TraceIdentifier);

            // Forming the basic details of the error
            var problemDetails = new ProblemDetails
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Detail = "An unexpected error has occurred.",
                Extensions = new Dictionary<string, object?>
                {
                    ["traceId"] = httpContext.TraceIdentifier,
                    ["timestamp"] = DateTime.Now.ToString("O") // ISO 8601
                }
            };

            // Adding debugging information only for the development environment
            if (_env.IsDevelopment())
            {
                problemDetails.Title = exception.GetBaseException().Message;

                // Formatting the call stack as an array of strings
                problemDetails.Extensions["stackTrace"] = FormatStackTrace(exception.StackTrace);

                // Recursively formatting the chain of internal exceptions
                problemDetails.Extensions["innerExceptions"] = FormatInnerExceptions(exception);

                // Secure request submission
                problemDetails.Extensions["request"] = new
                {
                    Method = httpContext.Request.Method,
                    Path = httpContext.Request.Path,
                    QueryString = httpContext.Request.QueryString.Value
                };
            }

            // Configuring the HTTP Response
            httpContext.Response.StatusCode = problemDetails.Status.Value;
            httpContext.Response.ContentType = "application/problem+json";

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }

        /// <summary>
        /// Formats the call stack into an array of strings for better readability
        /// </summary>
        private static string[]? FormatStackTrace(string? stackTrace)
        {
            if (string.IsNullOrWhiteSpace(stackTrace))
                return null;

            return stackTrace.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.RemoveEmptyEntries
            ).Select(line => line.Trim()).ToArray();
        }

        /// <summary>
        /// Recursively formats a chain of internal exceptions
        /// </summary>
        private static List<object>? FormatInnerExceptions(Exception? exception)
        {
            var innerExceptions = new List<object>();
            var current = exception?.InnerException;
            int depth = 0;

            while (current != null && depth < 10) // limit the depth for safety
            {
                innerExceptions.Add(new
                {
                    Type = current.GetType().FullName,
                    current.Message,
                    StackTrace = FormatStackTrace(current.StackTrace),
                    Source = current.Source
                });

                current = current.InnerException;
                depth++;
            }

            return innerExceptions.Count > 0 ? innerExceptions : null;
        }
    }
}