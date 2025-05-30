using Application.Products.Create;
using AutoMapper;
using Shared.Mappings.Converters;
using Web.Api.Endpoints.Products;

namespace Shared.Mappings.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>().ConvertUsing<CreateProductRequestToCommandConverter>();
        }
    }
}