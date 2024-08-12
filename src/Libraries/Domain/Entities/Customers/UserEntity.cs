namespace ContractorDocuments.Domain.Entities.Customers
{
    public class UserEntity : BaseEntity
    {
        public Fullname Fullname { get; set; } = new();
        public required string PhoneNumber { get; set; }
        public PasswordHash Password { get; set; } = new();
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations



        #endregion

        #region Ctor

        public UserEntity() { }

        #endregion
    }
}