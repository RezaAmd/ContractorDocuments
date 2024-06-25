using System.ComponentModel.DataAnnotations;

namespace ContractorDocuments.Domain.Enums
{
    public enum ProjectType
    {
        [Display(Name = "ساخت و ساز")]
        Construction = 5,

        [Display(Name = "بازسازی")]
        Renovation = 10
    }
}