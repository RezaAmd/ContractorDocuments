using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        #endregion
    }
}
