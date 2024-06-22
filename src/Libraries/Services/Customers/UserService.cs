using BuildingMaterialAccounting.Domain.Entities.Customers;

namespace BuildingMaterialAccounting.Application.Customers
{
    public class UserService
    {
        #region Fields

        private readonly ILogger<UserService> _logger;
        private readonly IQueryable<UserEntity> _userQuery;

        #endregion

        #region Ctor

        public UserService(IApplicationDbContext context,
            ILogger<UserService> logger)
        {
            _userQuery = context.Users;
            _logger = logger;
        }

        #endregion

        #region Methods

        //public async Task<UserEntity> FindByIdAsync(Guid id,
        //    CancellationToken cancellationToken = default)
        //{

        //}

        #endregion
    }
}