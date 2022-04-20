using System;
using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class TransactionService : ITransactionService
    {
       private readonly ICustomerRepository _customerRepository; 
       private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ICustomerRepository customerRepository , ITransactionRepository transactionRepository)
        {
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
        }

        public string Create(CreateTransferTransactionModel model)
        {
            var recipent = _customerRepository.GetByAccountNumberReturningCustomerObject(model.RecipentAccountNumber);
            var customer = _customerRepository.GetByPinReturningObj(model.Pin);
            if (customer.Balance > (model.Amount + 10))
            {
                customer.Balance -= model.Amount;
                recipent.Balance += model.Amount;
                var transaction = new Transaction
                {
                    CustomerId = customer.Id,
                    Amount = model.Amount,
                    Description = model.Description,
                    DateCreated = DateTime.Now,
                    AccountNumber = customer.AccountNumber,
                    Pin = model.Pin,
                };
                recipent.Transactions.Add(new Transaction{
                    CustomerId = recipent.Id,
                    Amount = model.Amount,
                    Description = "Deposit",
                    DateCreated = DateTime.Now,
                    AccountNumber = recipent.AccountNumber,
                    Pin = recipent.Pin
                });
                _transactionRepository.Create(transaction);
                return $"Sucessfully transfered {model.Amount} to {recipent.AccountNumber}";

            }
            else
            {
                return $"Insufficient Balance";
            }
        }

        public string Create(CreateWithdrawAndDepositTransactionModel model)
        {
            var customer = _customerRepository.GetByPinReturningObj(model.Pin);
            if(model.Description == "Deposit" && customer.AmountToBePaid == 0 && model.Amount > 0)
            {
                customer.Balance += model.Amount;
                var transaction = new Transaction
                {
                    CustomerId = customer.Id,
                    Amount = model.Amount,
                    Description = model.Description,
                    DateCreated = DateTime.Now,
                    AccountNumber = customer.AccountNumber,
                     Pin = model.Pin,
                };
                _transactionRepository.Create(transaction);
                return $"Sucessfully Deposited {model.Amount}";
            }
            else if(model.Description == "Deposit" && customer.AmountToBePaid > 0 && model.Amount > 0)
            {
                if (customer.AmountToBePaid > model.Amount)
                {
                    decimal x = model.Amount;
                    decimal y = customer.AmountToBePaid;
                    customer.AmountToBePaid = customer.AmountToBePaid - model.Amount;
                     var transaction = new Transaction
                    {
                       CustomerId = customer.Id,
                        
                        Description =  $"Deposited {x} and subtracted the loan that amounts to {y}",
                        DateCreated = DateTime.Now,
                        AccountNumber = customer.AccountNumber,
                         Pin = model.Pin,
                    };
                    _transactionRepository.Create(transaction);
                    return $"Sucessfully removed {model.Amount} from the amount of loan you borrowed {customer.AmountToBePaid + model.Amount}";
                }
                else if(customer.AmountToBePaid  <= model.Amount)
                {
                    decimal x = model.Amount;
                    decimal y = customer.AmountToBePaid;
                    model.Amount = model.Amount - customer.AmountToBePaid;
                    customer.Balance += model.Amount;
                    customer.AmountToBePaid = 0;
                    var transaction = new Transaction
                    {
                        CustomerId = customer.Id,
                        Description = $"Deposited {x} and subtracted the loan that amounts to {y}",
                        DateCreated = DateTime.Now,
                        AccountNumber = customer.AccountNumber,
                         Pin = model.Pin,
                    };
                    _transactionRepository.Create(transaction);
                    return $"Sucessfully removed {model.Amount} from the amount of loan you borrowed {customer.AmountToBePaid + model.Amount}";
                }
                return null;
            }
      
            else if(model.Description == "Withdraw" && customer.Balance > (model.Amount + 10))
            {
                customer.Balance -= model.Amount + 10;
                var transaction = new Transaction
                {
                    CustomerId = customer.Id,
                    Amount = model.Amount,
                    Description = model.Description,
                    DateCreated = DateTime.Now,
                   AccountNumber = customer.AccountNumber,
                    Pin = model.Pin,
                };
                _transactionRepository.Create(transaction);
                return $"Sucessfully withdrew {model.Amount} from {customer.Balance}";
            }
            else
            {
                return $"InSufficient Balance";
            }
        }
        public List<TransactionDto> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        public TransactionDto GetById(int id)
        {
            return _transactionRepository.GetById(id);
        }
    }
}