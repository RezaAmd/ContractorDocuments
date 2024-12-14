namespace ContractorDocuments.WebApi.Areas.Manage
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    public class MaterialController : ControllerBase
    {
        #region DI & Ctor

        public MaterialController()
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