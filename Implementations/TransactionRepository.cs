using System.Collections.Generic;
using System.Linq;

using MobileBankApp.Context;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
         private readonly MobileAppBankDbContext _context;

        public TransactionRepository(MobileAppBankDbContext context)
        {
            _context = context;
        }
        public void Create(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
        public List<TransactionDto> GetAll()
        {
            return _context.Transactions.Select(a => new TransactionDto 
            {
                Description = a.Description,
                Amount = a.Amount,
                DateCreated = a.DateCreated,
                AccountNumber = a.AccountNumber,
            }).ToList();
        }

        public TransactionDto GetById(int id)
        {
            var transaction = _context.Transactions.SingleOrDefault(a => a.Id == id);
            return new TransactionDto 
            {
                Description = transaction.Description,
                Amount = transaction.Amount,
                DateCreated = transaction.DateCreated,
                AccountNumber = transaction.AccountNumber,

            };
        }

        public Transaction GetByIdReturningTransactionObject(int id)
        {
            return _context.Transactions.SingleOrDefault(a => a.Id == id);
        }

        
    }
}