using DKT.Core.Admin.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DKT.Data.EntityFramework.Admin.Mapping
{
    class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts", "Admin")
                .HasKey(a => a.AccountId);
            builder.HasIndex(a => a.Username).IsUnique();
            builder.Property(a => a.Username).IsRequired().HasMaxLength(100);
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.PasswordHash).IsRequired().HasMaxLength(100);
            builder.Property(a => a.PasswordSalt).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Created).IsRequired();

            builder.HasMany(a => a.Roles).WithMany(r => r.Accounts);
        }
    }
}
