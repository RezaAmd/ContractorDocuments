using ContractorDocuments.Domain.Entities.Customers;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Customers
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> b)
        {
            b.ToTable("Users");

            // PhoneNumber
            b.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);
            b.HasIndex(e => e.PhoneNumber)
                .IsUnique();

            // Password
            b.OwnsOne(u => u.Password, u =>
            {
                u.Property(p => p.Value)
                .HasColumnName("Password")
                .HasMaxLength(256)
                .IsRequired(false)
                ;
            });

            // Fullname
            b.OwnsOne(u => u.Fullname, u =>
            {
                u.Property(fn => fn.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired(false);

                u.Property(fn => fn.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(50)
                .IsRequired(false);
            });

            // JoinedDate
            b.Property(u => u.CreatedOn)
                .ValueGeneratedOnAdd()
                .IsRequired();

            #region Relations



            #endregion
        }
    }
}