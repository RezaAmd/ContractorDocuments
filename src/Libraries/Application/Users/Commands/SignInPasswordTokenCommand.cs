using ContractorDocuments.Application.Users.Models;
using ContractorDocuments.Domain.ValueObjects;

namespace ContractorDocuments.Application.Users.Commands
{
    public class SignInPasswordTokenCommand : IRequest<(UserSignInStatus Status, UserAuthTokenModel AuthToken)>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class SignInPasswordTokenCommandHandler : IRequestHandler<SignInPasswordTokenCommand, (UserSignInStatus Status, UserAuthTokenModel AuthToken)>
    {
        private readonly UserAuthenticationService _userAuthenticationService;
        public SignInPasswordTokenCommandHandler(UserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        public async Task<(UserSignInStatus Status, UserAuthTokenModel AuthToken)> Handle(SignInPasswordTokenCommand request, CancellationToken cancellationToken)
        {
            var signinResult = await _userAuthenticationService.SignInPasswordTokenAsync(request.Username, PasswordHash.Parse(request.Password),
                cancellationToken);

            return signinResult;
        }
    }
}