using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Projects.Commands
{
    public class AddStageExpenseCommand : IRequest<Result>
    {
        public required Guid ProjectStageId { get; set; }
        public required string Title { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime PaidOn { get; set; }
        public string? Description { get; set; }
    }

    internal class AddStageExpenseCommandHandler : IRequestHandler<AddStageExpenseCommand, Result>
    {
        #region Fields & Ctor
        private readonly ProjectService _projectService;
        public AddStageExpenseCommandHandler(ProjectService projectService)
        {
            _projectService = projectService;
        }
        #endregion

        public async Task<Result> Handle(AddStageExpenseCommand request, CancellationToken cancellationToken)
        {
            var projectStageExpense = new ProjectStageExpenseEntity(request.Title, request.Amount, ExpenseType.Other, request.PaidOn, request.ProjectStageId);

            projectStageExpense.Description = request.Description;

            return await _projectService.AddStageExpenseAsync(projectStageExpense);
        }
    }
}
