namespace BuildingMaterialAccounting.Domain.Entities.Customers
{
    public class UserEntity : BaseEntity
    {
        public Fullname? Fullname { get; set; }
        public string PhoneNumber { get; private set; } = string.Empty;
        public PasswordHash? Password { get; set; } = null;
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations



        #endregion

        #region Ctor

        UserEntity() { }
        public UserEntity(string phoneNumber, PasswordHash password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }

        #endregion
    }
}