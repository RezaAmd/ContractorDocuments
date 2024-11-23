using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SignIn()
        {
            return Ok();
        }
    }
}