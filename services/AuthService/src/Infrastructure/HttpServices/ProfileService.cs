using Domain.Commands.Services;
using Domain.Interfaces.Services;
using Domain.Queries.Services;
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
                return await response.HandleErrorsAsync<TResponse>(ct);

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

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken ct)
        {
            //var uriBuilder = new UriBuilder(Routes.LOGIN);

            //var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            //query["loginValue"] = request.LoginValue;
            //query["loginType"] = Enum.GetName(typeof(LoginType), request.LoginType);
            //uriBuilder.Query = query.ToString();

            var response = await HttpClient.GetAsync(Routes.LOGIN_QUERY(request.LoginValue, request.LoginType), ct);

            if (!response.IsSuccessStatusCode)
                return await response.HandleErrorsAsync<LoginResponse>(ct);

            var responseContent = await response.Content.ReadFromJsonAsync<LoginResponse>(ct);

            return responseContent is null
                ? Result.Fail<LoginResponse>(new NotNullError(typeof(LoginResponse).ToString()))
                : Result.Ok(responseContent);
        }
    }
}