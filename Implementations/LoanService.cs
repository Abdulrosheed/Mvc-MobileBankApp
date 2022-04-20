using System;
using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ICustomerRepository _customerRepository;

        public LoanService(ILoanRepository loanRepository , ICustomerRepository customerRepository)
        {
            _loanRepository = loanRepository;
            _customerRepository = customerRepository;
        }

        public void Create(CreateLoanRequestModel model)
        {
           var customer =  _customerRepository.GetByPinReturningObj(model.Pin);
           if (customer.AmountToBePaid == 0)
           {
                customer.AmountToBePaid = model.Amount;
                customer.Balance += model.Amount;
                var loan = new Loan
                {
                    Amount = model.Amount,
                    DateCreated = DateTime.Now,
                    Pin = model.Pin,
                    AccountNumber = customer.AccountNumber,
                    CustomerId = customer.Id,
                };
                _loanRepository.Create(loan);
           }
         
        }

        public List<LoanDto> GetAll()
        {
            return _loanRepository.GetAll();
        }

        public LoanDto GetById(int id)
        {
            return _loanRepository.GetById(id);
        }
    }
}