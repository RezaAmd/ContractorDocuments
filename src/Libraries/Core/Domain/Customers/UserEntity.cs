namespace BuildingMaterialAccounting.Core.Domain.Customers
{
    public class UserEntity : BaseEntity
    {
        public Fullname? Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public PasswordHash Password { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations



        #endregion

        #region Ctor

        public UserEntity(string phoneNumber, PasswordHash password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }

        #endregion
    }
}