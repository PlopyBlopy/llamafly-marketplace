using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Repositories.Products;
using FluentResults;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries.Products
{
    internal sealed class GetAllProductsCardsRepository : IGetAllProductsCardsRepository
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsCardsRepository(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<List<ProductCardDto>>> GetAllCardsAsync(int? limit, CancellationToken ct)
        {
            var query = _context.Products
                .AsNoTracking();

            if (limit != null && limit != default)
                query = query.Take(limit.Value);

            var result = await query.Select(e => _mapper.Map<ProductCardDto>(e)).ToListAsync(ct);

            return Result.Ok(result);
        }
    }
}