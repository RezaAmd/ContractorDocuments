using ContractorDocuments.Domain.ValueObjects;

namespace UnitTests.Domain.Customers
{
    public class PasswordHashTests
    {
        [Theory]
        [InlineData("qdgnostf", "qdgnostf")]
        [InlineData("123456", "123456")]
        [InlineData("v%3g@l^8D/", "v%3g@l^8D/")]
        [InlineData("رمز عبور", "رمز عبور")]
        public void VerifyPassword_ShouldBe_Valid(string oldPassword, string newPassword)
        {
            // Act
            var oldPass = PasswordHash.Parse(oldPassword);

            // Assert
            Assert.True(oldPass.VerifyPassword(newPassword));
        }

        [Theory]
        [InlineData("123456", "654321")]
        [InlineData("v%3g@l^8D/", "v%3g@l^8D/1")]
        public void VerifyPassword_ShouldBe_InValid(string oldPassword, string newPassword)
        {
            // Act
            var oldPass = PasswordHash.Parse(oldPassword);

            // Assert
            Assert.False(oldPass.VerifyPassword(newPassword));
        }

        [Theory]
        [InlineData("", "123456")]
        [InlineData("Q5%g*8Ms#f", "")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("    ", null)]
        public void Create_NullOrEmpty_ShouldBe_Invalid(string? currentPassword, string? passwordInput)
        {
            // Act
            var currentPasswordObject = PasswordHash.Parse(currentPassword);

            // Assert
            Assert.False(currentPasswordObject.VerifyPassword(passwordInput));
        }
    }
}