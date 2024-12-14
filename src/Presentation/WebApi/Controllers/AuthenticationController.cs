namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SignInPassword()
        {
            return Ok();
        }
    }
}