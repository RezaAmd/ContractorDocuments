using ContractorDocuments.Application.Materials.Commands;
using ContractorDocuments.Application.Materials.Queries;
using ContractorDocuments.WebUI.Areas.Admin.Models.Materials;
using Microsoft.AspNetCore.Authorization;
using System.Threading;

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
        public async Task<IActionResult> Overview(CancellationToken cancellationToken)
        {
            var parentMaterials = await _mediator.Send(new GetAllParentMaterialQuery(),
                cancellationToken);

            var materials = parentMaterials.Select(m => new MaterialViewModel
            {
                Id = m.Id.ToString(),
                Name = m.Name
            }).ToList();

            return View(materials);
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
        [AllowAnonymous]
        public async Task<IActionResult> GetParents(CancellationToken cancellationToken)
        {
            var parentMaterials = await _mediator.Send(new GetAllParentMaterialQuery(),
                cancellationToken);
            return Ok(parentMaterials);
        }

        #endregion
    }
}
