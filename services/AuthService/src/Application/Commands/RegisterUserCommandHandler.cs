using AutoMapper;
using Domain.Commands;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Password;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands
{
    internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IProfileService _profileService;
        private readonly IAddPasswordRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IProfileService profileService, IAddPasswordRepository repository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _profileService = profileService;
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<RegisterUserResponse>> Handle(RegisterUserCommand command, CancellationToken ct)
        {
            var userRequest = _mapper.Map<RegisterUserRequest>(command);

            var response = await _profileService.RegisterUserAsync(userRequest, ct);

            if (response.IsFailed)
            {
                return Result.Fail<RegisterUserResponse>(response.Errors);
            }

            var userId = response.Value.UserId;
            var passwordHash = _passwordHasher.Hash(command.User.Password);

            var passwordModel = _mapper.Map<PasswordModel>((userId: userId, passwordHash: passwordHash));
            var result = await _repository.AddAsync(passwordModel, ct);

            return Result.Ok();
        }
    }
}