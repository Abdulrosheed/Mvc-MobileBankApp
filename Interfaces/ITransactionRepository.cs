using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface ITransactionRepository
    {
        void Create (Transaction transaction);
        TransactionDto GetById (int id);
        Transaction GetByIdReturningTransactionObject (int id);
        List<TransactionDto> GetAll();
    }
}