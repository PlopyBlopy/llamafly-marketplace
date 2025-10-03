using AutoMapper;
using Domain.DTO;
using Domain.Models.Profile;
using Shared.Extensions;

namespace Shared.Mapper.Converters
{
    internal class CreateProfileDtoToModelConverter : ITypeConverter<CreateProfileDto, ProfileModel>
    {
        public ProfileModel Convert(CreateProfileDto src, ProfileModel dest, ResolutionContext context)
        {
            var userId = context.GetRequiredItem<Guid>(ContextKeys.UserId);
            var patronymic = string.IsNullOrEmpty(src.Patronymic) ? null : src.Patronymic;

            return new ProfileModel(Guid.NewGuid(), userId, src.Name, src.Surname, patronymic, src.Age, src.Gender, DateTime.Now);
        }
    }
}