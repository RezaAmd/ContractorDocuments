using Microsoft.AspNetCore.Mvc;
using WebUI.Models.InputModels;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        #region Fields



        #endregion

        #region Ctor



        #endregion

        #region Pages

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn([FromForm] UserSignInInputModel userInputModel)
        {

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