using AutoMapper;
using Domain.Interfaces.Repositories.Products;
using Domain.Queries.Products;
using FluentResults;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries.Products
{
    internal class GetAllProductRepository : IGetAllProductRepository
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;

        public GetAllProductRepository(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // TODO: Реализовать limit для GetAllProductRepository
        public async Task<Result<GetAllProductsResponse>> GetAllAsync(CancellationToken ct)
        {
            var products = await _context.Products.ToListAsync(ct);

            return Result.Ok(new GetAllProductsResponse(products));
        }
    }
}