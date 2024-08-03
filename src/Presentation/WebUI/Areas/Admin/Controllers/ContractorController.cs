namespace ContractorDocuments.WebUI.Areas.Admin.Controllers
{
    public class ContractorController : AdminBaseController
    {
        #region Fields & Ctor

        private IMediator _mediator;
        public ContractorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        [HttpGet]
        public IActionResult Overview()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            return Ok();
        }
    }
}