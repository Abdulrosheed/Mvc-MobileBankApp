using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MobileBankApp.Context;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MobileAppBankDbContext _context;

        public CustomerRepository(MobileAppBankDbContext context)
        {
            _context = context;
        }


        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public bool ExistsByAccountName(string accountName)
        {
            return _context.Customers.Any(a =>a.AccountName == accountName);
        }

        public bool ExistsByAccountNumber(string accountNumber)
        {
            return _context.Customers.Any(a =>a.AccountNumber == accountNumber);
        }

        public bool ExistsByEmail(string email)
        {
            return _context.Customers.Any(a =>a.Email == email);
        }

        public bool ExistsByPhoneNumber(string phoneNumber)
        {
            return _context.Customers.Any(a =>a.PhoneNumber == phoneNumber);
        }

        public bool ExistsByPin(string pin)
        {
            return _context.Customers.Any(a =>a.Pin == pin);
        }

        public List<CustomerDto> GetAll()
        {
            return _context.Customers.Include(b => b.Transactions).Include(c => c.Loans).Select(a => new CustomerDto 
            {
                Id = a.Id,
                AccountNumber = a.AccountNumber,
                Balance = a.Balance,
                FirstName = a.FirstName,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
                AccountName = a.AccountName,
                Transactions = a.Transactions.Select(b => new TransactionDto 
                {
                    Amount = b.Amount,
                    DateCreated = b.DateCreated,
                    Description = b.Description,
                }).ToList(),
                Loans = a.Loans.Select(b => new LoanDto 
                {
                    Amount = b.Amount,
                    DateCreated = b.DateCreated,
                }).ToList()
            }).ToList();
        }

        public Customer GetByAccountNumberReturningCustomerObject(string accountNumber)
        {
           return _context.Customers.SingleOrDefault(a =>a.AccountNumber == accountNumber); 
        }

        public CustomerDto GetById(int id)
        {
            var customer = _context.Customers.Include(b => b.Transactions).Include(c => c.Loans).SingleOrDefault(a => a.Id == id);
            return new CustomerDto
            {
                Id = customer.Id,
                AccountNumber = customer.AccountNumber,
                Balance = customer.Balance,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                AccountName = customer.AccountName,
                Transactions = customer.Transactions.Select(b => new TransactionDto 
                {
                    Amount = b.Amount,
                    DateCreated = b.DateCreated,
                    Description = b.Description,
                }).ToList(),
                Loans = customer.Loans.Select(b => new LoanDto 
                {
                    Amount = b.Amount,
                    DateCreated = b.DateCreated,
                }).ToList()
            };
        }

        public Customer GetByIdReturningCustomerObject(int id)
        {
            return _context.Customers.SingleOrDefault(a =>a.Id == id);
        }

        public CustomerDto GetByPin(string pin)
        {
            var customer = _context.Customers.SingleOrDefault(a => a.Pin == pin);
            return new CustomerDto 
            {
                Id = customer.Id,
                AccountNumber = customer.AccountNumber,
                Balance = customer.Balance,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                AccountName = customer.AccountName,
            };
        }

        public Customer GetByPinReturningObj(string pin)
        {
            
            return _context.Customers.SingleOrDefault(a => a.Pin == pin);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}