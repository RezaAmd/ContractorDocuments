using BuildingMaterialAccounting.Domain.Entities.Customers;

namespace BuildingMaterialAccounting.Application.Customers
{
    public class UserReport
    {
        #region Fields

        private readonly IQueryable<UserEntity> _UserQuery;

        #endregion

        #region Ctor

        public UserReport(IApplicationDbContext context)
        {
            _UserQuery = context.Users.AsNoTracking();
        }

        #endregion

        #region Methods

        public async Task<UserEntity?> FindUserByUsernameAsync(string phoneNumber,
            CancellationToken cancellationToken)
            => await _UserQuery
            .Where(u => u.PhoneNumber == phoneNumber)
            .FirstOrDefaultAsync(cancellationToken);

        #endregion
    }
}