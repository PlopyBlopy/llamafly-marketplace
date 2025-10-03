using AutoMapper;
using Domain.DTO;
using Domain.Models.User;
using Shared.Extensions;

namespace Shared.Mapper.Converters
{
    internal class CreateUserDtoToModelConverter : ITypeConverter<CreateUserDto, UserModel>
    {
        public UserModel Convert(CreateUserDto src, UserModel dest, ResolutionContext context)
        {
            var userId = context.GetRequiredItem<Guid>(ContextKeys.UserId);
            var phoneNumber = string.IsNullOrEmpty(src.PhoneNumber) ? null : src.PhoneNumber;
            var email = string.IsNullOrEmpty(src.Email) ? null : src.Email;
            var currentDateTime = DateTime.Now;

            var userModel = new UserModel(userId, src.Login, phoneNumber, email, currentDateTime, currentDateTime);

            return userModel;
        }
    }
}