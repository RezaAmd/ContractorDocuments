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
                MeasureId = MaterialModel.MeasureId
            }, cancellationToken);

            return RedirectToAction("Overview");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("Overview");
            var materialWithChildren = await _mediator.Send(new GetParentMaterialDetailQuery
            {
                Id = Guid.Parse(id)
            });
            if (materialWithChildren == null)
                return RedirectToAction("Overview");
            // Prepare to view model.
            MaterialWithChildrenViewModel parentMaterialWithChildren = new();
            parentMaterialWithChildren.Id = materialWithChildren.Id.ToString();
            parentMaterialWithChildren.Name = materialWithChildren.Name;
            parentMaterialWithChildren.Children = new List<MaterialWithChildrenViewModel>();
            if (materialWithChildren.ChildrenMaterial != null)
            {
                parentMaterialWithChildren.Children = materialWithChildren.ChildrenMaterial.Select(m => new MaterialWithChildrenViewModel
                {
                    Id = m.Id.ToString(),
                    Name = m.Name
                }).ToList();
            }

            return View(parentMaterialWithChildren);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChild([FromForm] CreateMaterialInputModel materialInputModel,
            CancellationToken cancellationToken)
        {
            var createMaterialResult = await _mediator.Send(new CreateMaterialCommand
            {
                Name = materialInputModel.Name,
                MeasureId = materialInputModel.MeasureId,
                ParentMaterialId = materialInputModel.ParentMaterialId
            }, cancellationToken);

            return RedirectToAction("Detail", new { id = materialInputModel.ParentMaterialId });
        }

        #endregion

        #region Json

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var parentMaterials = await _mediator.Send(new GetAllMaterialsTreeQuery(),
                cancellationToken);
            return Ok(parentMaterials);
        }

        [HttpGet]
        public async Task<IActionResult> GetParents(CancellationToken cancellationToken)
        {
            var parentMaterials = await _mediator.Send(new GetAllParentMaterialQuery(),
                cancellationToken);
            return Ok(parentMaterials);
        }

        #endregion
    }
}