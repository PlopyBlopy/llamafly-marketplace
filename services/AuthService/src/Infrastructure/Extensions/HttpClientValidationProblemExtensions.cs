using FluentResults;

namespace Infrastructure.Extensions
{
    internal static class HttpClientValidationProblemExtensions
    {
        public static async Task<Result> HandleErrorsAsync(this HttpClient httpClient)
        {
            return Result.Ok();
            //var fields = new List<ValidationFieldError>();
            //fields.Add(new ValidationFieldError("message", "errorCode", "fieldName", "attemptedValue"));
            //return Result.Fail(new ValidationError("CreateAdmin", fields));
        }
    }
}