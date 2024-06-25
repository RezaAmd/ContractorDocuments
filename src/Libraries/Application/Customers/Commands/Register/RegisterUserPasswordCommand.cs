using ContractorDocuments.Application.Common.Models;
using ContractorDocuments.Application.Customers;
using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.ValueObjects;

namespace ContractorDocuments.Application.Customers.Commands.Register
{
    public class RegisterUserPasswordCommand : IRequest<Result>
    {
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
    }

    public class RegisterUserPasswordCommandHandler : IRequestHandler<RegisterUserPasswordCommand, Result>
    {
        #region Fields

        private readonly UserService _userService;

        #endregion

        #region Ctor

        public RegisterUserPasswordCommandHandler(UserService userService)
        {
            _userService = userService;
        }

        #endregion

        public async Task<Result> Handle(RegisterUserPasswordCommand request, CancellationToken cancellationToken)
        {
            // Create new instance of user.
            UserEntity newUser = new UserEntity
            {
                PhoneNumber = request.PhoneNumber,
                Password = PasswordHash.Parse(request.Password)
            };
            // Add user to database.
            return await _userService.AddAsync(newUser, cancellationToken);
        }
    }
}