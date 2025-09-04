using AutoMapper;
using Domain.Queries.Products;

namespace Shared.Mapper.Converters.Product
{
    internal sealed class GetByIdProductRequestToQueryConverter : ITypeConverter<GetByIdProductRequest, GetByIdProductQuery>
    {
        public GetByIdProductQuery Convert(GetByIdProductRequest source, GetByIdProductQuery destination, ResolutionContext context)
        {
            return new GetByIdProductQuery(source.Id);
        }
    }
}