using Domain.Commands;
using Domain.Commands.Services;
using Domain.Interfaces.Services;
using Domain.Queries.Services;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Extensions;
using System.Net.Http.Json;

namespace Infrastructure.HttpServices
{
    internal class ProfileService : HttpClientService, IProfileService
    {
        public ProfileService(IHttpClientFactory httpClientFactory) : base(httpClientFactory, Services.PROFILE_SERVICE)
        {
        }

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken ct)
        {
            var response = await HttpClient.GetAsync(Routes.LOGIN_QUERY(request.LoginValue, request.LoginType), ct);

            if (!response.IsSuccessStatusCode)
                return await response.HandleErrorsAsync<LoginResponse>(ct);

            var responseContent = await response.Content.ReadFromJsonAsync<LoginResponse>(ct);

            return responseContent is null
                ? Result.Fail<LoginResponse>(new NotNullError(typeof(LoginResponse).ToString()))
                : Result.Ok(responseContent);
        }

        public async Task<Result<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest request, CancellationToken ct)
        {
            var response = await HttpClient.PostAsJsonAsync(Routes.REGISTER_USER, request);

            if (!response.IsSuccessStatusCode)
                return await response.HandleErrorsAsync<RegisterUserResponse>(ct);

            var responseContent = await response.Content.ReadFromJsonAsync<RegisterUserResponse>(ct);

            return responseContent is null
                ? Result.Fail<RegisterUserResponse>(new NotNullError(typeof(RegisterUserResponse).ToString()))
                : Result.Ok(responseContent);
        }
    }
}