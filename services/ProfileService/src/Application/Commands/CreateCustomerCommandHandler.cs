using AutoMapper;
using Domain.Commands;
using Domain.DTO;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatoR.Alternative.Lite;
using Shared.Mapper;

namespace Application.Commands
{
    internal sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly ICreateCustomerRepository _repository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICreateCustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateCustomerResponse>> Handle(CreateCustomerCommand command, CancellationToken ct)
        {
            var model = _mapper.Map<CreateCustomerModelDto>(command, opts =>
            {
                opts.Items[ContextKeys.UserId] = Guid.NewGuid();
                opts.Items[ContextKeys.RoleId] = Guid.NewGuid();
            });

            var result = await _repository.AddAsync(model, ct);

            return result.Map(src => _mapper.Map<CreateCustomerResponse>(src));
        }
    }
}