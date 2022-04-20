
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MobileBankApp.Entities;

namespace MobileBankApp.Context
{
    public class MobileAppBankDbContext : DbContext
    {
        public MobileAppBankDbContext(DbContextOptions<MobileAppBankDbContext> options) : base(options)
        {

        }
         protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Transaction> Transactions{get;set;}
        public DbSet<Customer> Customers{get;set;}
        public DbSet<Admin> Admins {get;set;}
        public DbSet<Loan> Loans {get;set;}
        public DbSet<Subscription> Subscriptions{get;set;}
    

    }
}