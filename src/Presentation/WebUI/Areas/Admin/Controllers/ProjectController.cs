using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class ProjectController : AdminBaseController
    {
        #region DI & Ctor

        public ProjectController()
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
