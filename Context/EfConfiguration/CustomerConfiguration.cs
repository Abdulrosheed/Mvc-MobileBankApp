using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileBankApp.Entities;

namespace MobileBankApp.Context.EfConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(a => a.Email).IsRequired();
           builder.HasIndex(a => a.Pin).IsUnique();
           builder.HasIndex(a => a.PhoneNumber).IsUnique();
            builder.Property(a => a.DateOfBirth).IsRequired();
            builder.Property(a => a.FirstName).IsRequired();
            builder.Property(a => a.LastName).IsRequired();
            builder.Property(a => a.Gender).IsRequired();
            builder.Property(a => a.PhoneNumber).IsRequired();
            builder.Property(a => a.MaritalStatus).IsRequired();
            builder.Property(a => a.Address).IsRequired();
            builder.Property(a => a.DateCreated).IsRequired();
            builder.ToTable("Customer");
            builder.HasKey("Id");
            builder.HasMany(a => a.Transactions)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.Loans)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.Subscriptions)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}