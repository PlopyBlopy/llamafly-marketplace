using AutoMapper;
using Domain.Commands.Categories;

namespace Shared.Mapper.Converters.Category
{
    internal sealed class CreateCategoriesRangeRequestToCommandConverter : ITypeConverter<CreateCategoriesRangeRequest, CreateCategoriesRangeCommand>
    {
        public CreateCategoriesRangeCommand Convert(CreateCategoriesRangeRequest source, CreateCategoriesRangeCommand destination, ResolutionContext context)
        {
            return new CreateCategoriesRangeCommand(source.Categories);
        }
    }
}