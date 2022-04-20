using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileBankApp.Entities;

namespace MobileBankApp.Context.EfConfiguration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey("Id");
            builder.Property(a => a.Amount).IsRequired();
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.DateCreated).IsRequired();
            builder.Property(a => a.AccountNumber).IsRequired();
            builder.Property(a => a.Pin).IsRequired();
        }
    }
}