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

        public async Task<Result<GetAllProductsResponse>> GetAllAsync(CancellationToken ct)
        {
            var products = await _context.Products.Select(entity => _mapper.Map<GetByIdProductResponse>(entity)).ToListAsync();

            var response = new GetAllProductsResponse(products);

            return Result.Ok(response);
        }
    }
}