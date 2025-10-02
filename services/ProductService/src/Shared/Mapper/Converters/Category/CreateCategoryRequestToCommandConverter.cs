using AutoMapper;
using Domain.Commands.Categories;

namespace Shared.Mapper.Converters.Category
{
    internal class CreateCategoryRequestToCommandConverter : ITypeConverter<CreateCategoryRequest, CreateCategoryCommand>
    {
        public CreateCategoryCommand Convert(CreateCategoryRequest source, CreateCategoryCommand destination, ResolutionContext context)
        {
            return new CreateCategoryCommand(source.Title, source.ParentCategoryId);
        }
    }
}