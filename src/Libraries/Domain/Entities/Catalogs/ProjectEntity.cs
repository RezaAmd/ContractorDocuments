using BuildingMaterialAccounting.Domain.Entities;
using BuildingMaterialAccounting.Domain.Enums;

namespace BuildingMaterialAccounting.Domain.Entities.Catalogs
{
    public class ProjectEntity : BaseEntity
    {
        public string Title { get; set; }
        public DateTime StartIn { get; set; }
        public DateTime? EndIn { get; set; }
        public ProjectProcessStatusType Status { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations



        #endregion

        #region Ctor

        public ProjectEntity(string title, DateTime startIn)
        {
            Title = title;
            StartIn = startIn;
        }

        #endregion
    }
}