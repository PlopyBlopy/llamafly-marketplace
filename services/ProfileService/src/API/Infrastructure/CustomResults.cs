using FluentResults;
using FluentResults.Errors;

namespace API.Infrastructure
{
    public record MessageReason(string Message, ErrorType ErrorType, List<IError> Reasons);

    public static class CustomResults
    {
        public static IResult Problem<T>(Result<T> result)
        {
            if (result.IsSuccess)
                throw new InvalidOperationException();

            result.Errors[0].Metadata.TryGetValue("errorType", out var errorType);

            return Results.Problem(
                title: result.Errors.Count > 1 ? "There are a lot of errors." : "Errors received",
                //type: GetType((ErrorType)errorType),
                statusCode: GetStatusCode((ErrorType)errorType),
                extensions: GetErrors(result.Errors, result));

            static string GetTitle(IError error, ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.Validation => error.Message,
                    _ => "Server failure"
                };

            static string GetType(ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                    _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
                };

            static int GetStatusCode(ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.Validation => StatusCodes.Status400BadRequest,
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

            static Dictionary<string, object?>? GetErrors(IEnumerable<IError> errors, Result<T> result)
            {
                if (!result.Errors.Any())
                    return null;

                result.WithError(new Error("some error"));
                result.Errors[1].Reasons.Add(new Error("error"));

                List<MessageReason> messageReasons = new List<MessageReason>();
                for (int i = 0; i < result.Errors.Count; i++)
                {
                    result.Errors[i].Metadata.TryGetValue("errorType", out var errorType);

                    if (errorType != null)
                    {
                        messageReasons.Add(new MessageReason(GetTitle(result.Errors[i], (ErrorType)errorType), (ErrorType)errorType, result.Errors[i].Reasons));
                    }
                    else
                        messageReasons.Add(new MessageReason("Server failure", ErrorType.NotNull, result.Errors[i].Reasons));
                    //TODO: Изменить ErrorType.NotNull -> ErrorType.Error
                }

                return new Dictionary<string, object?>() { { "reason", messageReasons } };
            }
        }
    }
}