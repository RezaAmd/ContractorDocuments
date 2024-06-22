using Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace BuildingMaterialAccounting.Application.Customers
{
    public class UserReport
    {
        #region Fields

        private readonly Repository<UserEntity> _userRepository;

        #endregion

        #region Ctor

        public UserReport(Repository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        public async Task<UserEntity?> FindUserByUsernameAsync(string phoneNumber,
            CancellationToken cancellationToken)
            => await _userRepository.Table
            .Where(u => u.PhoneNumber == phoneNumber)
            .FirstOrDefaultAsync(cancellationToken);

        #endregion
    }
}