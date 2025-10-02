using AutoMapper;
using Domain.Commands;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands
{
    internal sealed class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand, RegisterCustomerResponse>
    {
        private readonly IAddPasswordRepository _repository;
        private readonly IMapper _mapper;

        public RegisterCustomerCommandHandler(IAddPasswordRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<RegisterCustomerResponse>> Handle(RegisterCustomerCommand command, CancellationToken ct)
        {
            return Result.Ok();
        }
    }
}