using AutoMapper;
using Domain.Commands;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands
{
    internal sealed class CreateAdminCommandHandler : ICommandHandler<CreateAdminCommand, CreateAdminResponse>
    {
        private readonly ICreateAdminRepository _repository;
        private readonly IMapper _mapper;

        public CreateAdminCommandHandler(ICreateAdminRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateAdminResponse>> Handle(CreateAdminCommand command, CancellationToken ct)
        {
            return Result.Ok();
        }
    }
}