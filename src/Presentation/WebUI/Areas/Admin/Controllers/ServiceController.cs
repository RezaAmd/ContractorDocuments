using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class ServiceController : AdminBaseController
    {
        #region Fields



        #endregion

        #region Ctor

        public ServiceController()
        {
            
        }

        #endregion

        [HttpGet]
        public IActionResult Overview()
        {
            return View();
        }
    }
}