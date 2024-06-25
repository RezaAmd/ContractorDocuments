using ContractorDocuments.Application.Customers.Commands.Signin;
using ContractorDocuments.WebUI.Models.InputModels;
using ContractorDocuments.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ContractorDocuments.WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        #region Fields

        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public AuthenticationController(IMediator mediator,
            IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;

        }

        #endregion

        #region Pages

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn([FromForm] UserSignInInputModel userInputModel,
            CancellationToken cancellationToken)
        {
            var signInResult = await _mediator.Send(new UserSignInPasswordCommand
            {
                Username = userInputModel.username,
                Password = userInputModel.password
            }, cancellationToken);
            if (signInResult.IsSuccess)
            {
                if (_httpContextAccessor.HttpContext is null)
                    return BadRequest("Http context error.");
                var user = signInResult.Data;
                if (user is null)
                    return BadRequest("User not found!");
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.PhoneNumber),
                };

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(3),
                    IsPersistent = userInputModel.IsPersistent,
                    IssuedUtc = DateTimeOffset.UtcNow
                };
#if DEBUG
                authProperties.ExpiresUtc.Value.AddDays(4);
#endif
                cancellationToken.ThrowIfCancellationRequested();
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                    authProperties);

                return Redirect("/Admin/Dashboard");
            }
            ModelState.AddModelError("", "Wrong user pass, please try again.");
            return View(userInputModel);
        }

        #endregion

        #region Json

        [HttpPost]
        public async Task<IActionResult> Logout(string? returnUrl)
        {
            if (_httpContextAccessor.HttpContext != null)
                await _httpContextAccessor.HttpContext.SignOutAsync();
            return Ok(new SignoutViewModel(returnUrl is null ? "/" : returnUrl));
        }

        #endregion
    }
}