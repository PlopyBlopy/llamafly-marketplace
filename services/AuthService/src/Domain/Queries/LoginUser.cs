using Domain.Queries.Services;
using MediatoR.Alternative.Lite;

namespace Domain.Queries
{
    public sealed record LoginUserResponse();
    public sealed record LoginUserQuery(string LoginValue, LoginType LoginType, string Password) : IQuery<LoginUserResponse>;
}