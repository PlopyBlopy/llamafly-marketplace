using Domain.Commands.Services;
using Domain.Interfaces.Services;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Abstractions;
using Infrastructure.Extensions;
using System.Net.Http.Json;

namespace Infrastructure.HttpServices
{
    internal class ProfileService : HttpClientService, IProfileService
    {
        public ProfileService(IHttpClientFactory httpClientFactory) : base(httpClientFactory, Services.PROFILE_SERVICE)
        {
        }

        private async Task<Result<TResponse>> CreateAsync<TRequest, TResponse>(TRequest request, string routes, CancellationToken ct)
        {
            var response = await HttpClient.PostAsJsonAsync(routes, request);

            if (!response.IsSuccessStatusCode)
                return await response.HandleValidationErrorsAsync<TResponse>(ct);

            var responseContent = await response.Content.ReadFromJsonAsync<TResponse>(ct);

            return responseContent is null
                ? Result.Fail<TResponse>(new NotNullError(typeof(TResponse).ToString()))
                : Result.Ok(responseContent);
        }

        public async Task<Result<CreateAdminResponse>> CreateAdminAsync(CreateAdminRequest request, CancellationToken ct) =>
            await CreateAsync<CreateAdminRequest, CreateAdminResponse>(request, Routes.CREATE_ADMIN, ct);

        public async Task<Result<CreateSellerResponse>> CreateSellerAsync(CreateSellerRequest request, CancellationToken ct) =>
            await CreateAsync<CreateSellerRequest, CreateSellerResponse>(request, Routes.CREATE_SELLER, ct);

        public async Task<Result<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken ct) =>
            await CreateAsync<CreateCustomerRequest, CreateCustomerResponse>(request, Routes.CREATE_CUSTOMER, ct);
    }
}