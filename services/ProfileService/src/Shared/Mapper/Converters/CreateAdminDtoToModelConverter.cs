using AutoMapper;
using Domain.DTO;
using Domain.Models.Admin;
using Shared.Extensions;

namespace Shared.Mapper.Converters
{
    internal class CreateAdminDtoToModelConverter : ITypeConverter<CreateAdminDto, AdminModel>
    {
        public AdminModel Convert(CreateAdminDto source, AdminModel destination, ResolutionContext context)
        {
            var userId = context.GetRequiredItem<Guid>(ContextKeys.UserId);

            return new AdminModel(Guid.NewGuid(), userId, DateTime.Now);
        }
    }
}