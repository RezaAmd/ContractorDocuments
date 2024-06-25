namespace BuildingMaterialAccounting.Domain.Enums
{
    public enum ProjectProcessStatusType
    {
        [Display(Name = "هنوز شروع نشده")]
        NotStartedYet = 0,
        [Display(Name = "درحال انجام")]
        InProgress = 5,
        [Display(Name = "تکمیل")]
        Completed = 10
    }
}