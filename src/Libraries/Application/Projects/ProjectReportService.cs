﻿using ContractorDocuments.Application.Projects.ViewModels;
using ContractorDocuments.Domain.Entities.Projects;
using System.Globalization;
using System.Net.Http.Headers;

namespace ContractorDocuments.Application.Projects
{
    public class ProjectReportService
    {
        #region Fields & Ctor

        private readonly ILogger<ProjectReportService> _logger;
        private readonly IQueryable<ProjectEntity> _projectNoTracking;
        private readonly IQueryable<ProjectStageEntity> _projectStageNoTracking;

        public ProjectReportService(ILogger<ProjectReportService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _projectNoTracking = context.Projects.AsNoTracking();
            _projectStageNoTracking = context.ProjectStages.AsNoTracking();
        }
        #endregion

        #region Methods

        public async Task<ProjectEntity?> FindByIdIncludeStagesAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _projectNoTracking
                .Include(p => p.Stages)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IList<ProjectEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _projectNoTracking
                .OrderByDescending(p => p.StartOn)
                .ToListAsync(cancellationToken);
        }

        public async Task<BoardViewModel?> GetProjectBoardAsync(Guid projectId,
            CancellationToken cancellationToken = default)
        {
            return await _projectNoTracking
                .Include(p => p.Stages!)
                .ThenInclude(ps => ps.ConstructStage!)
                .Include(p => p.Stages!)
                .ThenInclude(ps => ps.Materials)
                .Where(p => p.Id == projectId)
                .Select(p => new BoardViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    TotalExpense = p.Stages!.SelectMany(s => s.Materials!).Sum(psm => psm.UnitPrice * psm.Amount)
                    + p.Stages!.SelectMany(s => s.Expenses!).Sum(pse => pse.Amount),
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Stages = p.Stages!.OrderBy(s => s.ConstructStage!.DisplayOrder)
                    .Select(s => new BoardStageViewModel
                    {
                        Id = s.Id.ToString(),
                        Name = s.ConstructStage!.Name,
                        TotalExpense = s.Materials!.Sum(sm => sm.UnitPrice * sm.Amount)
                        + s.Expenses!.Sum(se => se.Amount),
                        Materials = s.Materials!.OrderByDescending(m => m.CreatedOn)
                        .Select(m => new StageMaterialViewModel
                        {
                            Id = m.Id.ToString(),
                            Name = m.Material!.Name,
                            Amount = m.Amount,
                            UnitPrice = m.UnitPrice
                        }).Take(3).ToList(),
                        Expenses = s.Expenses!.OrderByDescending(e => e.CreatedOn)
                        .Select(e => new StageExpenseViewModel
                        {
                            Id = e.Id.ToString(),
                            Title = e.Title,
                            Amount = e.Amount
                        }).Take(3).ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ProjectEntity?> GetProjectByIdIncludeDetailsAsync(Guid Id,
            CancellationToken cancellationToken = default)
        {
            var query = _projectNoTracking
                .Where(p => p.Id == Id)
                .Include(p => p.Contract)
                .Include(p => p.Stages!)
                    .ThenInclude(cs => cs.ConstructStage)
                .Include(p => p.Stages!)
                    .ThenInclude(ps => ps.Materials!)
                    .ThenInclude(psm => psm.Material)
                .Take(3)
                // .Include(p => p.Stages!)
                // .ThenInclude(cs => cs.Equipment).Take(3)
                // .Include(p => p.Stages!)
                // .ThenInclude(cs => cs.Expenses).Take(3)
                .AsQueryable();

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        #region Stages

        public async Task<IList<StageMaterialViewModel>> GetStageMaterialsAsync(Guid stageId,
            CancellationToken cancellationToken = default)
        {
            return await _projectStageNoTracking.Where(ps => ps.Id == stageId)
                .SelectMany(ps => ps.Materials!)
                .Include(psm => psm.Material)
                .OrderByDescending(ps => ps.CreatedOn)
                .Select(psm => new StageMaterialViewModel
                {
                    Id = psm.Id.ToString(),
                    Name = psm.Material!.Name,
                    Amount = psm.Amount,
                    UnitPrice = psm.UnitPrice,
                    PurchasedOn = psm.PurchacedOn.HasValue ? psm.PurchacedOn.Value.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")) : 
                    null,
                    TransportCost = psm.TransportCost,
                    TotalNetProfit = psm.TotalNetProfit,
                    TotalCost = psm.UnitPrice * psm.Amount + (psm.TransportCost.HasValue ? psm.TransportCost.Value : 0)
                }).ToListAsync(cancellationToken);
        }

        public async Task<IList<StageExpenseViewModel>> GetStageExpensesAsync(Guid stageId,
            CancellationToken cancellationToken = default)
        {
            return await _projectStageNoTracking.Where(ps => ps.Id == stageId)
                .Include(ps => ps.Expenses)
                .SelectMany(ps => ps.Expenses!)
                .OrderByDescending(pse => pse.PaidOn)
                .Select(pse => new StageExpenseViewModel
                {
                    Id = pse.Id.ToString(),
                    Title = pse.Title,
                    Amount = pse.Amount,
                    PaidOn = pse.PaidOn.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")),
                    Description = pse.Description
                }).ToListAsync(cancellationToken);
        }
        #endregion

        #endregion
    }
}
