using AutoMapper;
using Domain.Commands;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands
{
    internal sealed class RegisterSellerCommandHandler : ICommandHandler<RegisterSellerCommand, RegisterSellerResponse>
    {
        private readonly IAddPasswordRepository _repository;
        private readonly IMapper _mapper;

        public RegisterSellerCommandHandler(IAddPasswordRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<RegisterSellerResponse>> Handle(RegisterSellerCommand command, CancellationToken ct)
        {
            return Result.Ok();
        }
    }
}