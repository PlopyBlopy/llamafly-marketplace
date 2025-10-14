using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Repositories;
using Domain.Queries;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Queries
{
    internal sealed class LoginQueryHandler : IQueryHandler<LoginQuery, LoginResponse>
    {
        private readonly IGetUserIdRepository _repository;
        private readonly IMapper _mapper;

        public LoginQueryHandler(IGetUserIdRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<LoginResponse>> Handle(LoginQuery query, CancellationToken ct)
        {
            var dto = _mapper.Map<LoginDto>(query);

            var result = await _repository.GetAsync(dto, ct);

            return result.Map(src => _mapper.Map<LoginResponse>((true, src)));
        }
    }
}