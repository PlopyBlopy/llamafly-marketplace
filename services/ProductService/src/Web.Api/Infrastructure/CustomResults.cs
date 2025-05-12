using FluentResults;
using FluentResults.Errors;

namespace Web.Api.Infrastructure
{
    public static class CustomResults
    {
        public static IResult Problem<T>(Result<T> result)
        {
            if (result.IsSuccess)
                throw new InvalidOperationException();

            result.Errors[0].Metadata.TryGetValue("errorType", out var errorType);

            return Results.Problem(
                title: result.Errors.Count > 1 ? "There are a lot of errors." : GetTitle(result.Errors[0], (ErrorType)errorType),
                //detail: GetDetail(result.Errors[0]),
                type: GetType(result.Errors[0], (ErrorType)errorType),
                statusCode: GetStatusCode(result.Errors[0], (ErrorType)errorType),
                extensions: GetErrors(result.Errors));

            static string GetTitle(IError error, ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.Validation => error.Message,
                    _ => "Server failure"
                };

            static string GetType(IError error, ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                    _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
                };

            static int GetStatusCode(IError error, ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.Validation => StatusCodes.Status400BadRequest,
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

            static Dictionary<string, object?>? GetErrors(IEnumerable<IError> errors)
            {
                return new Dictionary<string, object?>()
                {
                    {"errors", errors }
                };
            }
        }
    }
}