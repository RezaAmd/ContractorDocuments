using BuildingMaterialAccounting.Domain.Entities;
using BuildingMaterialAccounting.Domain.Entities.Directory;

namespace BuildingMaterialAccounting.Domain.Entities.Materials
{
    public class MaterialMeasureEntity : BaseEntity
    {
        public Guid MaterialId { get; private set; }
        public Guid MeasurementUnitId { get; private set; }

        #region Relations

        public virtual MaterialEntity? Material { get; private set; }
        public virtual MeasureEntity? MeasurementUnit { get; private set; }

        #endregion

        #region Ctor

        public MaterialMeasureEntity(Guid materialId, Guid measurementUnitId)
        {
            if (materialId == Guid.Empty)
                throw new ArgumentNullException("Material id cannot be null or empty.");
            MaterialId = materialId;

            if (measurementUnitId == Guid.Empty)
                throw new ArgumentNullException("Measurement unit id cannot be null or empty.");
            MeasurementUnitId = measurementUnitId;
        }

        #endregion
    }
}