using ContractorDocuments.Application.Materials.Commands;
using ContractorDocuments.Application.Materials.Queries;
using ContractorDocuments.WebUI.Areas.Admin.Models.Materials;

namespace ContractorDocuments.WebUI.Areas.Admin.Controllers
{
    public class MaterialController : AdminBaseController
    {
        #region DI & Ctor

        private readonly IMediator _mediator;
        public MaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Pages

        [HttpGet]
        public IActionResult Overview()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateMaterialInputModel MaterialModel,
            CancellationToken cancellationToken)
        {
            var createMaterialResult = await _mediator.Send(new CreateMaterialCommand
            {
                Name = MaterialModel.Name,
                MeasureId = MaterialModel.MeasureId,
                ParentMaterialId = MaterialModel.ParentMaterialId
            }, cancellationToken);

            return RedirectToAction("Overview");
        }

        [HttpGet]
        public async Task<IActionResult> GetParents(CancellationToken cancellationToken)
        {
            var parentMaterials = await _mediator.Send(new GetAllParentMaterialQuery(),
                cancellationToken);
            return Ok();
        }

        #endregion
    }
}
