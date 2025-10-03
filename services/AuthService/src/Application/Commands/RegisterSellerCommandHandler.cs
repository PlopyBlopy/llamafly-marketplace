using AutoMapper;
using Domain.Commands;
using Domain.Commands.Services;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Password;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands
{
    internal sealed class RegisterSellerCommandHandler : ICommandHandler<RegisterSellerCommand, RegisterSellerResponse>
    {
        private readonly IProfileService _profileService;
        private readonly IAddPasswordRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterSellerCommandHandler(IProfileService profileService, IAddPasswordRepository repository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _profileService = profileService;
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<RegisterSellerResponse>> Handle(RegisterSellerCommand command, CancellationToken ct)
        {
            var createAdminRequest = _mapper.Map<CreateSellerRequest>(command);

            var response = await _profileService.CreateSellerAsync(createAdminRequest, ct);

            if (response.IsFailed)
            {
                return Result.Fail<RegisterSellerResponse>(response.Errors);
            }

            var userId = response.Value.UserId;
            var passwordHash = _passwordHasher.Hash(command.User.Password);

            var passwordModel = _mapper.Map<PasswordModel>((userId: userId, passwordHash: passwordHash));
            var result = await _repository.AddAsync(passwordModel, ct);

            return Result.Ok();
        }
    }
}