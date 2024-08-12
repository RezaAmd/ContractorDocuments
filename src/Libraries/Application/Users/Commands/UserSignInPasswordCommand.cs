using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.ValueObjects;

namespace ContractorDocuments.Application.Users.Commands
{
    public sealed class UserSignInPasswordCommand : IRequest<Result<UserEntity>>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public sealed class UserSignInPasswordCommandHandler : IRequestHandler<UserSignInPasswordCommand, Result<UserEntity>>
    {
        #region DI & Ctor

        private readonly UserAuthenticationService _userAuthenticationService;

        public UserSignInPasswordCommandHandler(UserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        #endregion

        public async Task<Result<UserEntity>> Handle(UserSignInPasswordCommand request, CancellationToken cancellationToken)
        {
            var signinResult = await _userAuthenticationService.SignInPasswordAsync(request.Username, PasswordHash.Parse(request.Password));

            if (signinResult.User == null)
                return Result.Fail("کاربر مورد نظر یافت نشد.");

            if (signinResult.Status == UserSignInStatus.Success)
                return Result.Ok(signinResult.User);
            return Result.Fail();
        }
    }
}