namespace Core.Domain.Customers
{
    public class UserEntity : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        #region Relations



        #endregion

        #region Ctor

        public UserEntity(string phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }

        #endregion
    }
}