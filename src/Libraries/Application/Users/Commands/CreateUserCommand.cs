using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.ValueObjects;

namespace ContractorDocuments.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<Result<UserEntity>>
    {
        public Fullname? Fullname { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserEntity>>
    {
        #region Field & Ctor

        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly UserService _userService;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
            UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        #endregion

        public async Task<Result<UserEntity>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Create new instance of user.
            var newUser = request.Adapt<UserEntity>();
            // Add new user.
            var addUserResult = await _userService.AddAsync(newUser, cancellationToken);
            // Log when error.
            if (addUserResult.IsSuccess == false)
            {
                _logger.LogError("Add user was failed!");
            }
            return addUserResult;
        }
    }
}
