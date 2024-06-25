using ContractorDocuments.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectContractEntity : BaseEntity
    {
        public ProjectContractType ContractTypeId { get; set; }
    }
}
