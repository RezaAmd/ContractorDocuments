using ContractorDocuments.Application.Users.Models;
using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.ValueObjects;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ContractorDocuments.Application.Users
{
    public class UserAuthenticationService
    {
        #region DI & Ctor

        private readonly ILogger<UserAuthenticationService> _logger;
        private readonly UserReport _userReport;
        private readonly UserModelFactory _userModelFactory;
        private readonly IJwtBearerProvider _jwtProvider;
        private readonly AuthenticationSettingModel _authenticationSettingModel;
        public UserAuthenticationService(ILogger<UserAuthenticationService> logger,
            UserReport userReport,
            UserModelFactory userModelFactory,
            IJwtBearerProvider jwtProvider,
            IOptions<AuthenticationSettingModel> authenticationSettingOption)
        {
            _logger = logger;
            _userReport = userReport;
            _userModelFactory = userModelFactory;
            _jwtProvider = jwtProvider;
            _authenticationSettingModel = authenticationSettingOption.Value;
        }

        #endregion

        #region Methods

        public async Task<(UserSignInStatus Status, UserEntity? User)> SignInPasswordAsync(string username, PasswordHash password,
            CancellationToken cnacellationToken = default)
        {
            // Find user by phone number.
            var user = await _userReport.FindUserByUsernameAsync(username, cnacellationToken);
            // Notfound
            if (user is null)
            {

                return (UserSignInStatus.WrongUsernamePassword, null);
            }
            // Wrong password
            if (user.Password is null || user.Password != password)
            {

                return (UserSignInStatus.WrongUsernamePassword, null);
            }
            // Signin success
            return (UserSignInStatus.Success, user);
        }

        public async Task<(UserSignInStatus Status, UserAuthTokenModel AuthToken)> SignInPasswordTokenAsync(string username, PasswordHash password,
            CancellationToken cancellationToken = default)
        {
            var signinResult = await SignInPasswordAsync(username, password);

            if (signinResult.Status != UserSignInStatus.Success || signinResult.User == null)
            {
                return (signinResult.Status, new());
            }

            // Create auth token model instance.
            var authTokenModel = new UserAuthTokenModel();
            // Prepare user claims.
            var claims = PrepareAuthClaims(signinResult.User);

            #region Token

            var ExpiresAt = DateTime.Now
                .AddMinutes(
                    _authenticationSettingModel.TokenExpirationMinutes.HasValue ?
                    _authenticationSettingModel.TokenExpirationMinutes.Value : 25);
            authTokenModel.Token = await _jwtProvider.GenerateTokenAsync(claims, ExpiresAt, cancellationToken);
            authTokenModel.TokenExpireAt = ExpiresAt.ToString("yyyy/MM/dd HH:mm:ss");

            #endregion

            #region Refresh Token

            var refreshTokenExpireAt = DateTime.Now.AddDays(7);
            authTokenModel.RefreshToken = await _jwtProvider.GenerateTokenAsync(claims, refreshTokenExpireAt, cancellationToken);
            authTokenModel.RefreshTokenExpireAt = refreshTokenExpireAt.ToString("yyyy/MM/dd HH:mm:ss");

            #endregion

            return (UserSignInStatus.Success, authTokenModel);
        }

        #endregion

        private List<Claim> PrepareAuthClaims(UserEntity user)
        {
            return new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.PhoneNumber)
            };
        }

        private UserAuthTokenModel PrepareAuthToken()
        {
            return new UserAuthTokenModel { };
        }
    }
}
