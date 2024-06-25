using ContractorDocuments.Application.Common.Interfaces;
using ContractorDocuments.Domain.Entities.Customers;

namespace ContractorDocuments.Application.Users
{
    public class UserReport
    {
        #region Fields

        private readonly IQueryable<UserEntity> _userQuery;

        #endregion

        #region Ctor

        public UserReport(IApplicationDbContext context)
        {
            _userQuery = context.Users.AsNoTracking();
        }

        #endregion

        #region Methods

        public async Task<UserEntity?> FindUserByUsernameAsync(string phoneNumber,
            CancellationToken cancellationToken)
            => await _userQuery
            .Where(u => u.PhoneNumber == phoneNumber)
            .FirstOrDefaultAsync(cancellationToken);

        public async Task<IList<UserEntity>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _userQuery.ToListAsync();
        }

        #endregion
    }
}