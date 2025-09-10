using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Repositories.Categories;
using Domain.Interfaces.Repositories.Products;
using Domain.Product;
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

            ProductConstraints.SORT_PROP sortProp;
            ProductConstraints.SORT_ORDER sortOrder;

            if (!Enum.TryParse(filters.SortProp, true, out sortProp))
                sortProp = ProductConstraints.SORT_PROP.rating;

            if (!Enum.TryParse(filters.SortOrder, true, out sortOrder))
                sortOrder = ProductConstraints.SORT_ORDER.desc;

            switch (sortProp)
            {
                case ProductConstraints.SORT_PROP.price:
                    query = sortOrder == ProductConstraints.SORT_ORDER.asc
                        ? query.OrderBy(c => c.Price)
                        : query.OrderByDescending(c => c.Price);
                    break;

                case ProductConstraints.SORT_PROP.rating:
                    query = sortOrder == ProductConstraints.SORT_ORDER.asc
                        ? query.OrderBy(c => c.Rating)
                        : query.OrderByDescending(c => c.Rating);
                    break;

                default:
                    query = query.OrderByDescending(c => c.Rating);
                    break;
            }

            var result = await query.Select(e => _mapper.Map<ProductCardDto>(e)).ToListAsync(ct);

            return Result.Ok(result);
        }
    }
}