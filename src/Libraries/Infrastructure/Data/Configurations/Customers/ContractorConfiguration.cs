using ContractorDocuments.Domain.Entities.Customers;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Customers
{
    internal class ContractorConfiguration : IEntityTypeConfiguration<ContractorEntity>
    {
        public void Configure(EntityTypeBuilder<ContractorEntity> builder)
        {
            builder.ToTable("Contractors");

            // Fullname
            builder.OwnsOne(b => b.Fullname, b =>
            {
                b.Property(fn => fn.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired(false);

                b.Property(fn => fn.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(50)
                .IsRequired(false);
            });

            // Email
            builder.Property(b => b.Email)
                .HasMaxLength(150)
                .IsRequired(false);

            // CompanyName
            builder.Property(b => b.CompanyName)
                .IsRequired(false)
                .HasMaxLength(100);

            // CreatedOn
            builder.Property(b => b.CreatedOn);

            #region Relations

            // Phones
            builder.HasMany(b => b.Phones)
                .WithOne(cp => cp.Contractor)
                .HasForeignKey(cp => cp.ContractorId);

            #endregion
        }
    }
}