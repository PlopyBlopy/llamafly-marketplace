using AutoMapper;
using Domain.Category;
using Domain.Commands.Categories;
using Domain.DTO;
using Domain.Queries.Categories;
using Shared.Mapper.Converters.Category;

namespace Shared.Mapper.Profiles
{
    public sealed class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // POST
            CreateMap<CreateCategoryRequest, CreateCategoryCommand>().ConvertUsing<CreateCategoryRequestToCommandConverter>();
            CreateMap<CreateCategoryCommand, CategoryModel>().ConvertUsing<CreateCategoryCommandToModelConverter>();
            CreateMap<Guid, CreateCategoryResponse>().ConstructUsing(src => new CreateCategoryResponse(src));

            CreateMap<CreateCategoriesRangeRequest, CreateCategoriesRangeCommand>().ConvertUsing<CreateCategoriesRangeRequestToCommandConverter>();
            CreateMap<CreateCategoriesRangeCommand, CreateCategoriesRangeModelDto>().ConvertUsing<CreateCategoriesRangeCommandToModelDtoConverter>();
            CreateMap<CreateCategoriesRangeWithIdRequest, CreateCategoriesRangeWithIdCommand>().ConstructUsing(src => new CreateCategoriesRangeWithIdCommand(src.Categories));
            CreateMap<CreateCategoriesRangeWithIdCommand, CreateCategoriesRangeModelDto>().ConvertUsing<CreateCategoriesRangeWithIdCommandToModelDtoConverter>();

            // GET

            CreateMap<Guid, GetByIdCategoryQuery>().ConstructUsing(src => new GetByIdCategoryQuery(src));
            CreateMap<CategoryModel, GetByIdCategoryResponse>().ConvertUsing<CategoryModelToGetByIdResponseConverter>();
            CreateMap<Guid, CategoryExistQuery>().ConstructUsing(src => new CategoryExistQuery(src));
            CreateMap<bool, CategoryExistResponse>().ConstructUsing(src => new CategoryExistResponse(src));

            CreateMap<List<CategoryWithSubDto>, GetAllCategoriesResponse>().ConstructUsing(src => new GetAllCategoriesResponse(src));
            CreateMap<List<CategoryWithSubMinDto>, GetAllCategoriesMinResponse>().ConstructUsing(src => new GetAllCategoriesMinResponse(src));

            // PATCH

            // DELETE
        }
    }
}