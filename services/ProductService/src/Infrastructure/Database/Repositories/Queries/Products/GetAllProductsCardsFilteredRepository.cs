using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Repositories.Categories;
using Domain.Interfaces.Repositories.Products;
using FluentResults;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries.Products
{
    internal sealed class GetAllProductsCardsFilteredRepository : IGetAllProductsCardsFilteredRepository
    {
        private readonly IDataBaseContext _context;
        private readonly ICategoryExistRepository _categoryExistRepository;
        private readonly IMapper _mapper;

        public GetAllProductsCardsFilteredRepository(IDataBaseContext context, ICategoryExistRepository categoryExistRepository, IMapper mapper)
        {
            _context = context;
            _categoryExistRepository = categoryExistRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProductCardDto>>> GetAllCardsFilteredAsync(ProductCardFiltersDto filters, CancellationToken ct)
        {
            var query = _context.Products.AsNoTracking();

            if (!string.IsNullOrEmpty(filters.Search))
                query = query.Where(e => e.Title.Contains(filters.Search));

            if (filters.CategoryId != null && filters.CategoryId != Guid.Empty)
            {
                var isExist = await _categoryExistRepository.IsExistAsync(filters.CategoryId.Value, ct);
                if (isExist.Value)
                {
                    query = query.Where(e => e.CategoryId == filters.CategoryId);
                }
            }

            if (filters.Price > 0)
            {
                query = query.Where(e => e.Price == filters.Price);
            }
            else
            {
                query = query.Where(e => e.Price > 0);
            }

            if (filters.Rating > 0)
            {
                query = query.Where(e => e.Rating == filters.Rating);
            }
            else
            {
                query = query.Where(e => e.Rating > 0);
            }

            var result = await query.Select(e => _mapper.Map<ProductCardDto>(e)).ToListAsync(ct);

            return Result.Ok(result);
        }
    }
}