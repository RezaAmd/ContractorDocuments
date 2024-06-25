namespace ContractorDocuments.WebUI.Areas.Admin.Models.Users
{
    public partial class UserViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public required string PhoneNumber { get; set; }
        public string CreatedOn { get; set; }
    }
}
