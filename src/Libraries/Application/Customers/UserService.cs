using ContractorDocuments.Application.Common.Interfaces;
using ContractorDocuments.Application.Common.Models;
using ContractorDocuments.Domain.Entities.Customers;

namespace ContractorDocuments.Application.Customers
{
    public class UserService
    {
        #region Fields

        private readonly ILogger<UserService> _logger;
        private readonly IApplicationDbContext _context;

        #endregion

        #region Ctor

        public UserService(IApplicationDbContext context,
            ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        #endregion

        #region Methods

        //public async Task<UserEntity> FindByIdAsync(Guid id,
        //    CancellationToken cancellationToken = default)
        //{

        //}

        public async Task<Result> AddAsync(UserEntity user,
            CancellationToken cancellationToken = default)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            if (Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken)))
                return Result.Ok();
            return Result.Fail();
        }

        #endregion
    }
}