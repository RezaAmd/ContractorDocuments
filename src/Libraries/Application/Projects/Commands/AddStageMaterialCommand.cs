﻿using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Projects.Commands
{
    public class AddStageMaterialCommand : IRequest<Result>
    {
        public string StageId { get; set; }
        public string MaterialId { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalNetProfit { get; set; }
    }
    internal class AddStageMaterialCommandHandler : IRequestHandler<AddStageMaterialCommand, Result>
    {
        #region Fields & Ctor

        private readonly ProjectService _projectService;
        public AddStageMaterialCommandHandler(ProjectService projectService)
        {
            _projectService = projectService;
        }

        #endregion

        public async Task<Result> Handle(AddStageMaterialCommand request, CancellationToken cancellationToken)
        {
            var newSupply = new ProjectStageMaterialEntity()
            {
                Amount = request.Amount,
                MaterialId = Guid.Parse(request.MaterialId),
                ProjectStepId = Guid.Parse(request.StageId),
                UnitPrice = request.UnitPrice,
                TotalNetProfit = request.TotalNetProfit
            };
            return await _projectService.AddStageMaterialAsync(newSupply, cancellationToken);
        }
    }
}