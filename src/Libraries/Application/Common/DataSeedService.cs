using ContractorDocuments.Domain.Entities.Directory;
using ContractorDocuments.Domain.Entities.Equipment;
using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Common
{
    public class DataSeedService
    {
        private readonly ILogger<DataSeedService> _logger;
        private readonly IApplicationDbContext _context;
        public DataSeedService(ILogger<DataSeedService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Result> InsertSampleDataAsync(CancellationToken cancellationToken)
        {
            // Prepare construct stages.
            var constructStages = PrepareConstructStageSamples();
            await _context.ConstructStages.AddRangeAsync(constructStages);

            // Prepare masures.
            var measures = PrepareMeasureSamples();
            await _context.Measures.AddRangeAsync(measures);

            // Prepare equipments.
            var equipments = PrepareEquipmentSamples();
            await _context.Equipments.AddRangeAsync(equipments);

            return await _context.SaveChangeAsync(cancellationToken);
        }

        #region Utils

        private IList<ConstructStageEntity> PrepareConstructStageSamples()
        {
            return new List<ConstructStageEntity>()
            {
                new ConstructStageEntity()
                {
                    Name = "اداری", ProjectTypeId = ProjectType.Construction, DisplayOrder = 5
                },
                new ConstructStageEntity()
                {
                    Name = "فنداسیون", ProjectTypeId = ProjectType.Construction, DisplayOrder = 10
                },
                new ConstructStageEntity()
                {
                    Name = "اسکلت بندی", ProjectTypeId = ProjectType.Construction, DisplayOrder = 15
                },
                new ConstructStageEntity()
                {
                    Name = "دیوارچینی", ProjectTypeId = ProjectType.Construction, DisplayOrder = 20
                },
                new ConstructStageEntity()
                {
                    Name = "MEP (مکانیکی، برقی، لوله کشی)", ProjectTypeId = ProjectType.Construction, DisplayOrder = 25
                },
                new ConstructStageEntity()
                {
                    Name = "نصب امکانات و تجهیزات", ProjectTypeId = ProjectType.Construction, DisplayOrder = 30
                }
            };
        }
        private IList<MeasureEntity> PrepareMeasureSamples()
        {
            return new List<MeasureEntity>()
            {
                new MeasureEntity(name: "کیلوگرم", systemKeyword: "kilogram") { DisplayOrder = 5 },
                new MeasureEntity(name: "گرم", systemKeyword: "gram") { DisplayOrder = 10 },
                new MeasureEntity(name: "تن", systemKeyword: "ton") { DisplayOrder = 15 },
                new MeasureEntity(name: "عدد", systemKeyword: "number") { DisplayOrder = 20 },
                new MeasureEntity(name: "متر", systemKeyword: "meter") { DisplayOrder = 25 },
                new MeasureEntity(name: "سانت", systemKeyword: "centimeter") { DisplayOrder = 30 }
            };
        }
        private IList<EquipmentEntity> PrepareEquipmentSamples()
        {
            return new List<EquipmentEntity>() {
                new EquipmentEntity("دستکش"),
                new EquipmentEntity("متر"),
                new EquipmentEntity("کلاه ایمنی"),
                new EquipmentEntity("بیل"),
                new EquipmentEntity("فرغون"),
                new EquipmentEntity("داربست"),
                new EquipmentEntity("بیل مکانیکی")
            };
        }

        #endregion
    }
}