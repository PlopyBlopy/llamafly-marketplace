using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Queries.Products.GetAll;
using Domain.Queries.Products.GetById;
using FluentResults;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Products.Queries
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

        public async Task<Result<GetAllProductResponse>> GetAllAsync(CancellationToken ct)
        {
            var products = await _context.Products.Select(entity => _mapper.Map<GetByIdProductResponse>(entity)).ToListAsync();

            var response = new GetAllProductResponse(products);

            return Result.Ok(response);
        }
    }
}