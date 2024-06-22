using BuildingMaterialAccounting.Application.Customers.Commands.Signin;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.InputModels;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
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
            return Redirect("/");
        }

        #endregion

        #region Json

        [HttpPost]
        public IActionResult Logout(string? returnUrl)
        {
            return Ok(new SignoutViewModel(returnUrl is null ? "/" : returnUrl));
        }

        #endregion
    }
}