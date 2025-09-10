using AutoMapper;
using Domain.Commands.Products;
using Domain.DTO;
using Domain.Product;
using Domain.Queries.Products;
using Shared.Mapper.Converters.Product;

namespace Shared.Mapper.Profiles
{
    public sealed class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // POST
            CreateMap<CreateProductRequest, CreateProductCommand>().ConvertUsing<CreateProductRequestToCommandConverter>();
            CreateMap<CreateProductCommand, ProductModel>().ConvertUsing<CreateProductCommandToModelConverter>();
            CreateMap<Guid, CreateProductResponse>().ConstructUsing(src => new CreateProductResponse(src));
            CreateMap<CreateProductsRangeWithIdRequest, CreateProductsRangeWithIdCommand>().ConstructUsing(src => new CreateProductsRangeWithIdCommand(src.Products));
            CreateMap<CreateProductsRangeWithIdCommand, CreateProductsRangeModelDto>().ConvertUsing<CreateProductsRangeWithIdCommandToModelDtoConverter>();

            // PATCH
            CreateMap<UpdateProductRequest, UpdateProductCommand>().ConvertUsing<UpdateProductRequestToCommandConverter>();
            CreateMap<ProductModel, UpdateProductResponse>().ConvertUsing<ProductModelToUpdateProductResponseConverter>();

            // GET
            CreateMap<GetByIdProductRequest, GetByIdProductQuery>().ConvertUsing<GetByIdProductRequestToQueryConverter>();
            CreateMap<ProductModel, GetByIdProductResponse>().ConvertUsing<ProductModelToGetByIdResponseConverter>();

            CreateMap<ProductModel, ProductCardDto>().ConvertUsing<ProductModelToCardDtoConverter>();
            CreateMap<GetAllProductsCardsRequest, GetAllProductsCardsQuery>().ConstructUsing(src => new GetAllProductsCardsQuery(src.Limit));
            CreateMap<GetAllProductsCardsFilteredRequest, GetAllProductsCardsFilteredQuery>().ConstructUsing(src => new GetAllProductsCardsFilteredQuery(src.Filters));
            CreateMap<List<ProductCardDto>, GetAllProductsCardsResponse>().ConstructUsing(src => new GetAllProductsCardsResponse(src));
            CreateMap<List<ProductCardDto>, GetAllProductsCardsFilteredResponse>().ConstructUsing(src => new GetAllProductsCardsFilteredResponse(src));

            // DELETE
            CreateMap<RemoveProductRequest, RemoveProductCommand>().ConvertUsing<RemoveProductRequestToCommandConverter>();
            CreateMap<Guid, RemoveProductResponse>().ConstructUsing(src => new RemoveProductResponse(src));
        }
    }
}