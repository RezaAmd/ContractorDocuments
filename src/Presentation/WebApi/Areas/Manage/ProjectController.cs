namespace ContractorDocuments.WebApi.Areas.Manage
{
    [Route("[controller]/[action]")]
    [ApiController]
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