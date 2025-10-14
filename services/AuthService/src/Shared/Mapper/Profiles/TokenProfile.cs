using AutoMapper;
using Domain.Models.RefreshToken;

namespace Shared.Mapper.Profiles
{
    internal class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<(Guid userId, Guid refreshToken, DateTime expiresAt), RefreshTokenModel>().ConstructUsing(src =>
                new RefreshTokenModel(Guid.NewGuid(), src.userId, src.refreshToken.ToString(), false, src.expiresAt, DateTime.Now));
        }
    }
}