using System.Collections.Generic;
using System.Transactions;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface ITransactionService
    {
        string Create (CreateTransferTransactionModel model);
        string Create (CreateWithdrawAndDepositTransactionModel model);
        TransactionDto GetById (int id);
        List<TransactionDto> GetAll();
    }
}