using FluentValidation;

namespace WebUI.Models.InputModels
{
    public record UserSignInInputModel(string username, string password, bool IsPersistent);
    public class UserSignInInputModelValidator : AbstractValidator<UserSignInInputModel>
    {
        public UserSignInInputModelValidator()
        {
            RuleFor(x => x.username)
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(20);

            RuleFor(x => x.password)
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(50);
        }
    }
}
