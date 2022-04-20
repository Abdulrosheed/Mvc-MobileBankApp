using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileBankApp.Entities;

namespace MobileBankApp
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loan");
            builder.HasKey("Id");
            builder.Property(a => a.Amount).IsRequired();
            builder.Property(a => a.DateCreated).IsRequired();
            builder.Property(a => a.AccountNumber).IsRequired();
            builder.Property(a => a.Pin).IsRequired();
            // builder.HasOne(a => a.Customer)
            // .WithMany(a => a.Loans)
            // .HasForeignKey(a => a.CustomerId)
            // .OnDelete(DeleteBehavior.Cascade);
        }
    }
}