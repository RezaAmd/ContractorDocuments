using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class MaterialController : AdminBaseController
    {
        #region DI & Ctor



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
