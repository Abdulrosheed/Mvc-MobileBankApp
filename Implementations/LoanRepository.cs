using System.Collections.Generic;
using System.Linq;
using MobileBankApp.Context;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class LoanRepository : ILoanRepository
    {
        private readonly MobileAppBankDbContext _context;

        public LoanRepository(MobileAppBankDbContext context)
        {
            _context = context;
        }
        public void Create(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public List<LoanDto> GetAll()
        {
            return _context.Loans.Select(a => new LoanDto 
            {
                Amount = a.Amount,
                DateCreated = a.DateCreated,
                AccountNumber = a.AccountNumber,
                Name = $"{a.Customer.FirstName} {a.Customer.LastName}",
            }).ToList();
        }

        public LoanDto GetById(int id)
        {
            var loan = _context.Loans.SingleOrDefault(a => a.Id == id);
            return new LoanDto 
            {
                
                Amount = loan.Amount,
                DateCreated = loan.DateCreated,
                AccountNumber = loan.AccountNumber,
                Name = $"{loan.Customer.FirstName} {loan.Customer.LastName}",
            };
        }

        public Loan GetByIdReturningLoanObject(int id)
        {
            return _context.Loans.SingleOrDefault(a => a.Id == id);
        }
    }
}