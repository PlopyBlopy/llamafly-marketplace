using AutoMapper;
using Domain.Commands.Products.Create;
using Domain.Commands.Products.Remove;
using Domain.Commands.Products.Update;
using Domain.Product;
using Domain.Queries.Products.GetById;
using Shared.Mapper.Converters;

namespace Shared.Mapper.Profiles
{
    public sealed class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>().ConvertUsing<CreateProductRequestToCommandConverter>();
            CreateMap<CreateProductCommand, ProductModel>().ConvertUsing<CreateProductCommandToModelConverter>();

            CreateMap<UpdateProductRequest, UpdateProductCommand>().ConvertUsing<UpdateProductRequestToCommandConverter>();
            CreateMap<ProductModel, UpdateProductResponse>().ConvertUsing<ProductModelToUpdateProductResponseConverter>();

            CreateMap<GetByIdProductRequest, GetByIdProductQuery>().ConvertUsing<GetByIdProductRequestToQueryConverter>();
            CreateMap<ProductModel, GetByIdProductResponse>().ConvertUsing<ProductModelToGetByIdResponseConverter>();

            CreateMap<RemoveProductRequest, RemoveProductCommand>().ConvertUsing<RemoveProductRequestToCommandConverter>();
            CreateMap<Guid, RemoveProductResponse>().ConvertUsing<GuidToRemoveProductResponseConverter>();
        }
    }
}