using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorDocuments.Application.Projects.Commands
{
    public class TransferStageMaterialToAnotherStageCommand : IRequest<Result>
    {
        /// <summary>
        /// Which material to transfer?
        /// </summary>
        public Guid StageMaterialId { get; set; }
        /// <summary>
        /// Which project stage to transfer material?
        /// </summary>
        public Guid ProjectStageId { get; set; }
    }

    internal class TransferStageMaterialToAnotherStageCommandHandler : IRequestHandler<TransferStageMaterialToAnotherStageCommand, Result>
    {
        #region Fields & Ctor

        private readonly ProjectService _projectService;
        public TransferStageMaterialToAnotherStageCommandHandler(ProjectService projectService)
        {
            _projectService = projectService;
        }

        #endregion

        public async Task<Result> Handle(TransferStageMaterialToAnotherStageCommand request, CancellationToken cancellationToken)
        {
            // Find stage material.
            var stageMaterial = await _projectService.FindStageMaterialByIdAsync(request.StageMaterialId,
                cancellationToken);
            if (stageMaterial == null)
            {
                return Result.Fail("Stage material was not found!");
            }

            // Find project stage.
            var projectStage = await _projectService.FindProjectStageByIdAsync(request.ProjectStageId,
                cancellationToken);
            if(projectStage == null)
            {
                return Result.Fail("Project stage was not found!");
            }

            // Transfer and update.
            stageMaterial.ProjectStepId = projectStage.Id;
            return await _projectService.UpdateStageMaterialAsync(stageMaterial);
        }
    }
}