using ContractorDocuments.Domain.Entities.Customers;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Customers
{
    internal class ContractorPhoneConfiguration : IEntityTypeConfiguration<ContractorPhoneEntity>
    {
        public void Configure(EntityTypeBuilder<ContractorPhoneEntity> builder)
        {
            builder.ToTable("ContractorPhones");

            // PhoneNumber
            builder.Property(b => b.PhoneNumber)
                .HasMaxLength(15);

            #region Relations

            // Contractor
            builder.HasOne(b => b.Contractor)
                .WithMany(c => c.Phones)
                .HasForeignKey(b => b.ContractorId);

            #endregion
        }
    }
}