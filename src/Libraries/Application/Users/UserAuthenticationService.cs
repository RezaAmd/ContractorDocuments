using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.ValueObjects;

namespace ContractorDocuments.Application.Users
{
    public class UserAuthenticationService
    {
        #region DI & Ctor

        private readonly ILogger<UserAuthenticationService> _logger;
        private readonly UserReport _userReport;

        public UserAuthenticationService(ILogger<UserAuthenticationService> logger,
            UserReport userReport)
        {
            _logger = logger;
            _userReport = userReport;
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

        #endregion
    }
}
