using FluentResults;
using FluentResults.Errors;
using System.Net.Http.Json;

namespace Infrastructure.Extensions
{
    internal static class ResponseMessageErrorsExtensions
    {
        public static async Task<Result<TResponse>> HandleErrorsAsync<TResponse>(this HttpResponseMessage responseMessage, CancellationToken ct)
        {
            if (responseMessage == null)
                return Result.Fail<TResponse>("The response message cannot be null");

            var errorResponse = await responseMessage.Content.ReadFromJsonAsync<Domain.DTO.ResultsError.ErrorResponse>(ct);

            if (errorResponse?.Reason == null || !errorResponse.Reason.Any())
                return Result.Fail<TResponse>(errorResponse.Title);

            var errors = errorResponse.Reason
                .SelectMany(e => e.Reasons)
                .Select(r => new ValidationFieldError(r.Message, r.Metadata.ErrorCode, r.Metadata.FieldName, r.Metadata.AttemptedValue))
                .ToList();

            return Result.Fail<TResponse>(new ValidationError(typeof(TResponse).Name.ToString(), errors));
        }

        public static Result<TResponse> HandleErrorsAsync<TResponse>(this ProfileServiceGrpc.ErrorResponse responseMessage)
        {
            if (responseMessage == null)
                return Result.Fail<TResponse>("The response message cannot be null");

            if (responseMessage.Reason == null || !responseMessage.Reason.Any())
                return Result.Fail<TResponse>(responseMessage.Title);

            var errors = responseMessage.Reason
                .SelectMany(e => e.Reasons)
                .Select(r => new ValidationFieldError(r.Message, r.Metadata.ErrorCode, r.Metadata.FieldName, r.Metadata.AttemptedValue))
                .ToList();

            return Result.Fail<TResponse>(new ValidationError(typeof(TResponse).Name.ToString(), errors));
        }
    }
}