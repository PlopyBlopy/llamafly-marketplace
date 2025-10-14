using AutoMapper;
using Domain.Commands;
using Domain.DTO;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatoR.Alternative.Lite;
using Shared.Mapper;

namespace Application.Commands
{
    internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly ICreateUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(ICreateUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand command, CancellationToken ct)
        {
            var model = _mapper.Map<CreateUserModelDto>(command, opts =>
            {
                opts.Items[ContextKeys.UserId] = Guid.NewGuid();
                opts.Items[ContextKeys.RoleId] = Guid.NewGuid();
            });

            var result = await _repository.AddAsync(model, ct);

            return result.Map(src => _mapper.Map<CreateUserResponse>(src));
        }
    }
}