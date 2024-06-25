using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMaterialAccounting.Domain.Entities.Projects
{
    public class ProjectContractEntity : BaseEntity
    {
        public ProjectContractType ContractTypeId { get; set; }
    }
}
