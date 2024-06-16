using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        #region Fields



        #endregion

        #region Ctor

        public DashboardController()
        {
            
        }

        #endregion

        #region Pages

        [HttpGet]
        public IActionResult Overview()
        {
            return View();
        }

        #endregion
    }
}