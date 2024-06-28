namespace ContractorDocuments.Domain.Enums
{
    public enum ContractorSpeciallyType
    {
        [Display(Name = "پیمانکار عمومی")]
        GeneralContractor,
        [Display(Name = "حفاری")]
        Excavation,
        [Display(Name = "بتن کار")]
        Concrete,
        [Display(Name = "قاب بندی")]
        Framing,
        [Display(Name = "فولاد کار")]
        Steel,
        [Display(Name = "در و پنجره")]
        WindowAndDoor,
        [Display(Name = "برق")]
        Electrical,
        [Display(Name = "لوله کشی")]
        Plumbing,
        [Display(Name = "HVAC")]
        HVAC,
        [Display(Name = "اعلام حریق و آب پاش")]
        FireAlarmAndSprinkler,
        [Display(Name = "سقف سازی")]
        Roofing,
        [Display(Name = "عایق بندی")]
        Insulation,
        [Display(Name = "دیوار خشک")]
        Drywall,
        [Display(Name = "نوار")]
        Taping,
        [Display(Name = "گچ کاری")]
        Plaster,
        [Display(Name = "کفپوش")]
        Flooring,
        [Display(Name = "نجاری")]
        FinishCarpentry,
        [Display(Name = "نقاشی")]
        Painting,
        [Display(Name = "سنگ تراشی")]
        Masonry,
        [Display(Name = "محوطه سازی")]
        Landscaping
    }
}