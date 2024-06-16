using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        #region Fields



        #endregion

        #region Ctor

        public UserController()
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

        #region Json

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Update()
        {
            return Ok();
        }

        #endregion
    }
}
