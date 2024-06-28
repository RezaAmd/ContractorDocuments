using ContractorDocuments.Domain.Entities.Customers;

namespace ContractorDocuments.Application.Users
{
    public class UserService
    {
        #region Fields & Ctor

        private readonly ILogger<UserService> _logger;
        private readonly IApplicationDbContext _context;
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
            return await _context.SaveChangeAsync(cancellationToken);
        }

        #endregion
    }
}