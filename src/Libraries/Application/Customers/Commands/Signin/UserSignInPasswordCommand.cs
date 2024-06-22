using BuildingMaterialAccounting.Domain.ValueObjects;

namespace BuildingMaterialAccounting.Application.Customers.Commands.Signin
{
    public sealed class UserSignInPasswordCommand : IRequest<Result>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public sealed class UserSignInPasswordCommandHandler : IRequestHandler<UserSignInPasswordCommand, Result>
    {
        #region DI & Ctor

        private readonly UserAuthenticationService _userAuthenticationService;

        public UserSignInPasswordCommandHandler(UserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        #endregion

        public async Task<Result> Handle(UserSignInPasswordCommand request, CancellationToken cancellationToken)
        {
            var signinResult = await _userAuthenticationService.SignInPasswordAsync(request.Username, PasswordHash.Parse(request.Password));
            if (signinResult.Status == UserSignInStatus.Success)
                return Result.Ok(signinResult.User);
            return Result.Fail();
        }
    }
}
