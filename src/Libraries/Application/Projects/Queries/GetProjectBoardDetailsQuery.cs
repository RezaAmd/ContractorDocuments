using ContractorDocuments.Application.Projects.ViewModels;
using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Projects.Queries
{
    public class GetProjectBoardDetailsQuery : IRequest<BoardViewModel?>
    {
        public required Guid Id { get; set; }
    }

    internal class GetProjectBoardDetailsQueryHandler : IRequestHandler<GetProjectBoardDetailsQuery, BoardViewModel?>
    {
        #region Fields & Ctor

        private readonly ProjectReportService _projectReportService;
        public GetProjectBoardDetailsQueryHandler(ProjectReportService projectReportService)
        {
            _projectReportService = projectReportService;
        }

        #endregion

        public async Task<BoardViewModel?> Handle(GetProjectBoardDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _projectReportService.GetProjectBoardAsync(request.Id, cancellationToken);
        }
    }
}