using AutoMapper;
using Domain.Commands;
using Domain.DTO;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatoR.Alternative.Lite;
using Shared.Mapper;

namespace Application.Commands
{
    internal sealed class CreateSellerCommandHandler : ICommandHandler<CreateSellerCommand, CreateSellerResponse>
    {
        private readonly ICreateSellerRepository _repository;
        private readonly IMapper _mapper;

        public CreateSellerCommandHandler(ICreateSellerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateSellerResponse>> Handle(CreateSellerCommand command, CancellationToken ct)
        {
            var model = _mapper.Map<CreateSellerModelDto>(command, opts =>
            {
                opts.Items[ContextKeys.UserId] = Guid.NewGuid();
                opts.Items[ContextKeys.RoleId] = Guid.NewGuid();
            });

            var result = await _repository.AddAsync(model, ct);

            return result.Map(src => _mapper.Map<CreateSellerResponse>(src));
        }
    }
}