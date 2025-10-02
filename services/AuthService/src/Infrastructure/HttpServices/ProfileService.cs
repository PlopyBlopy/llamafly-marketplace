using Domain.Commands.Services;
using Domain.Interfaces.Services;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Abstractions;
using System.Net.Http.Json;

namespace Infrastructure.HttpServices
{
    internal class ProfileService : HttpClientService, IProfileService
    {
        public ProfileService(IHttpClientFactory httpClientFactory) : base(httpClientFactory, Services.PROFILE_SERVICE)
        {
        }

        public async Task<Result<CreateAdminResponse>> CreateAdminAsync(CreateAdminRequest request, CancellationToken ct)
        {
            var response = await HttpClient.PostAsJsonAsync(Routes.CREATE_ADMIN, request);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>(ct);

                var errors = errorResponse.Reason
                    .SelectMany(e => e.Reasons)
                    .Select(r => new ValidationFieldError(r.Message, r.Metadata.ErrorCode, r.Metadata.FieldName, r.Metadata.AttemptedValue))
                    .ToList();

                return Result.Fail<CreateAdminResponse>(new ValidationError(typeof(CreateAdminResponse).ToString(), errors));
            }

            var responseContent = await response.Content.ReadFromJsonAsync<CreateAdminResponse>(ct);

            return responseContent is null
                ? Result.Fail<CreateAdminResponse>(new NotNullError(typeof(CreateAdminResponse).ToString()))
                : Result.Ok(responseContent);
        }

        public Task<Result<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CreateSellerResponse>> CreateSellerAsync(CreateSellerRequest request, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }

    public record ErrorResponse(
        string Type,
        string Title,
        int Status,
        List<ErrorList> Reason,
        string TraceId);

    public record ErrorList(string Message, ErrorType ErrorType, List<ErrorDetail> Reasons);

    public record ErrorDetail(
        List<Reason> Reasons,
        string Message,
        ErrorMetadata Metadata);

    public record Reason(
        string Message,
        ReasonMetadata Metadata);

    public record ReasonMetadata(
        string ErrorCode,
        string FieldName,
        string AttemptedValue);

    public record ErrorMetadata(
        string ErrorCode,
        string FieldName,
        string AttemptedValue);
}