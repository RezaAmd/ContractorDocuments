using ContractorDocuments.Application.Projects.ViewModels;

namespace ContractorDocuments.Application.Projects.Queries
{
    public class GetStageExpensesQuery : IRequest<IList<StageExpenseViewModel>>
    {
        public required Guid StageId { get; set; }
    }

    internal class GetStageExpensesQueryHandler : IRequestHandler<GetStageExpensesQuery, IList<StageExpenseViewModel>>
    {
        #region Fields & Ctor

        private readonly ProjectReportService _projectReportService;

        public GetStageExpensesQueryHandler(ProjectReportService projectReportService)
        {
            _projectReportService = projectReportService;
        }

        #endregion

        public async Task<IList<StageExpenseViewModel>> Handle(GetStageExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _projectReportService.GetStageExpensesAsync(request.StageId, cancellationToken);
        }
    }
}