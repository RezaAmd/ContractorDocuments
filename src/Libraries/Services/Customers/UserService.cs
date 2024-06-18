using BuildingMaterialAccounting.Core.Data;
using BuildingMaterialAccounting.Core.Domain.Customers;

namespace BuildingMaterialAccounting.Services.Customers
{
    public class UserService
    {
        #region DI & Ctor

        private readonly ILogger<UserService> _logger;
        private readonly Repository<UserEntity> _userRepository;

        public UserService(Repository<UserEntity> userRepository,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        #endregion

        //public async Task<UserEntity> FindByIdAsync(Guid id,
        //    CancellationToken cancellationToken = default)
        //{

        //}
    }
}