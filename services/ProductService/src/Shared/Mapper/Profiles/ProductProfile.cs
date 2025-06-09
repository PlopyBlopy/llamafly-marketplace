using AutoMapper;
using Domain.Commands.Products.Create;
using Domain.Product;
using Shared.Mapper.Converters;

namespace Shared.Mapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>().ConvertUsing<CreateProductRequestToCommandConverter>();
            CreateMap<CreateProductCommand, ProductModel>().ConvertUsing<CreateProductCommandToModelConverter>();
        }
    }
}