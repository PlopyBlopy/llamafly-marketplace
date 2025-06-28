using AutoMapper;
using Domain.Queries.Products.GetById;

namespace Shared.Mapper.Converters
{
    internal sealed class GetByIdProductRequestToQueryConverter : ITypeConverter<GetByIdProductRequest, GetByIdProductQuery>
    {
        public GetByIdProductQuery Convert(GetByIdProductRequest source, GetByIdProductQuery destination, ResolutionContext context)
        {
            return new GetByIdProductQuery(source.Id);
        }
    }
}