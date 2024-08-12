using ContractorDocuments.Domain.ValueObjects;

namespace UnitTests.Domain.Customers
{
    public class FullnameTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("      ", "    ")]
        public void Create_Should_ReturnNull_WhenValueIsNullOrEmpty(string? name, string? surname)
        {
            // Act
            var fullname = new Fullname(name, surname);

            // Assert
            Assert.Empty(fullname.GetFullName());
        }

        [Theory]
        [InlineData("Reza", "Ahmadi", "Reza Ahmadi")]
        [InlineData("رضا", "احمدی", "رضا احمدی")]
        [InlineData("حسین   ", "  خادمی", "حسین خادمی")]
        [InlineData("", "", "")]
        public void Create_Should_ReturnFullname(string? name, string? surname, string? fullname)
        {
            // Act
            Fullname fullName = new(name, surname);
            // Assert
            Assert.Equal(fullName.GetFullName(), fullname);
        }
    }
}