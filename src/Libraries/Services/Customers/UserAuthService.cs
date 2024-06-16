namespace BuildingMaterialAccounting.Services.Customers
{
    public class UserAuthService
    {
        #region DI & Ctor

        private readonly ILogger<UserAuthService> _logger;
        private readonly UserService _userService;

        public UserAuthService(ILogger<UserAuthService> logger,
            UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        #endregion

        #region Methods



        #endregion
    }
}
