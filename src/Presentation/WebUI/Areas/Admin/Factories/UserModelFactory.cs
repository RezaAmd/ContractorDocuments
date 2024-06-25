using ContractorDocuments.Application.Customers;

namespace ContractorDocuments.WebUI.Areas.Admin.Factories
{
    public class UserModelFactory
    {
        #region DI & Ctor

        private readonly ILogger<UserModelFactory> _logger;
        private readonly UserService _userService;

        public UserModelFactory(ILogger<UserModelFactory> logger,
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
