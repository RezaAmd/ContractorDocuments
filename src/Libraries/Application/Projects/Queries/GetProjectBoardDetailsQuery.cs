using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Projects.Queries
{
    public class GetProjectBoardDetailsQuery : IRequest<ProjectEntity?>
    {
        public required Guid Id { get; set; }
    }

    internal class GetProjectBoardDetailsQueryHandler : IRequestHandler<GetProjectBoardDetailsQuery, ProjectEntity?>
    {
        #region Fields & Ctor

        private readonly ProjectReportService _projectReportService;
        public GetProjectBoardDetailsQueryHandler(ProjectReportService projectReportService)
        {
            _projectReportService = projectReportService;
        }

        #endregion

        public async Task<ProjectEntity?> Handle(GetProjectBoardDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _projectReportService.GetProjectByIdIncludeDetailsAsync(request.Id, cancellationToken);
        }
    }
}