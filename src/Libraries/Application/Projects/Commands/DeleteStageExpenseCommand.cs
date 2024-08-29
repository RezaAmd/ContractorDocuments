namespace ContractorDocuments.Application.Projects.Commands
{
    public class DeleteStageExpenseCommand : IRequest<Result>
    {
        public Guid ExpenseId { get; set; }
    }

    internal class DeleteStageExpenseCommandHandler : IRequestHandler<DeleteStageExpenseCommand, Result>
    {
        #region DI & Ctor

        private readonly ProjectService _projectService;
        public DeleteStageExpenseCommandHandler(ProjectService projectService)
        {
            _projectService = projectService;
        }

        #endregion

        public async Task<Result> Handle(DeleteStageExpenseCommand request,
            CancellationToken cancellationToken)
        {
            // Find expense from db.
            var expense = await _projectService.FindStageExpenseAsync(request.ExpenseId, cancellationToken);
            if(expense == null)
            {
                return Result.Fail();
            }
            // Delete expense from db.
            var deleteExpenseResult = await _projectService.DeleteStageExpenseAsync(expense, cancellationToken);
            return deleteExpenseResult;
        }
    }
}