using ContractorDocuments.Domain.Entities.Customers;

namespace ContractorDocuments.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IList<UserEntity>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IList<UserEntity>>
    {
        #region Field & Ctor

        private readonly ILogger<GetAllUsersQueryHandler> _logger;
        private readonly UserReport _userReport;

        public GetAllUsersQueryHandler(ILogger<GetAllUsersQueryHandler> logger,
            UserReport userReport)
        {
            _logger = logger;
            _userReport = userReport;
        }

        #endregion

        public Task<IList<UserEntity>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _userReport.GetAllUsersAsync(cancellationToken);
        }
    }
}
