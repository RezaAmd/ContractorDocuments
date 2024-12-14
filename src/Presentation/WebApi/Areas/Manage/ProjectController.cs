namespace ContractorDocuments.WebApi.Areas.Manage
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    public class ProjectController : ControllerBase
    {
        #region DI & Ctor

        public ProjectController()
        {

        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}