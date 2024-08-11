namespace ContractorDocuments.Application.Projects.Commands
{
    public class DeleteStageMaterialCommand : IRequest<Result>
    {
        public Guid StageMaterialId { get; set; }
    }

    internal class DeleteStageMaterialCommandHandler : IRequestHandler<DeleteStageMaterialCommand, Result>
    {
        #region Fields & Ctor

        private readonly ProjectService _projectService;
        public DeleteStageMaterialCommandHandler(ProjectService projectService)
        {
            _projectService = projectService;
        }

        #endregion

        public async Task<Result> Handle(DeleteStageMaterialCommand request, CancellationToken cancellationToken)
        {
            var stageMaterial = await _projectService.FindStageMaterialByIdAsync(request.StageMaterialId,
                cancellationToken);
            if(stageMaterial == null)
            {
                return Result.Fail("Project stage material was not found!");
            }

            return await _projectService.DeleteStageMaterialAsync(stageMaterial, cancellationToken);

        }
    }
}