using MediatR;

namespace WebApi.Controllers
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

        [HttpPost]
        public async Task<IActionResult> SignInPassword(CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}