namespace BuildingMaterialAccounting.Domain.Enums
{
    public enum ProjectContractType
    {
        [Display(Name = "پروژه شخصی")]
        Personal = 0,
        [Display(Name = "مقطوع یا مبلغ یکجا")]
        LumpSum = 5,
        [Display(Name = "درصدی")]
        Percentage = 10,
        [Display(Name = "دستمزدی یا اجرتی")]
        Salary = 15,
        [Display(Name = "فهرست بهایی")]
        PriceList = 20
    }
}