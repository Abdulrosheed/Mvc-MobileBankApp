using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileBankApp.Entities;

namespace MobileBankApp.Context.EfConfiguration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admin");
            builder.HasKey("Id");
            builder.Property(a => a.Email).IsRequired();
          //  builder.HasIndex(a => a.Email).IsUnique();
          //  builder.HasIndex(a => a.PhoneNumber).IsUnique();
            builder.Property(a => a.Age).IsRequired();
            builder.Property(a => a.FirstName).IsRequired();
            builder.Property(a => a.LastName).IsRequired();
            builder.Property(a => a.Gender).IsRequired();
            builder.Property(a => a.PhoneNumber).IsRequired();
            builder.Property(a => a.MaritalStatus).IsRequired();
            builder.Property(a => a.PassWord).IsRequired();
            builder.Property(a => a.Address).IsRequired();
            builder.Property(a => a.DateCreated).IsRequired();
        }
    }
}