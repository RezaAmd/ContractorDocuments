using ContractorDocuments.Application.Users;
using ContractorDocuments.Application.Users.Commands;

namespace ContractorDocuments.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        #region DI & Ctor

        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInPasswordTokenCommand signinCommand, CancellationToken cancellationToken)
        {
            var signinResult = await _mediator.Send(signinCommand, cancellationToken);

            if (signinResult.Status == UserSignInStatus.Success)
                return Ok(signinResult.AuthToken);

            return BadRequest(signinResult.Status);
        }

        #endregion
    }
}