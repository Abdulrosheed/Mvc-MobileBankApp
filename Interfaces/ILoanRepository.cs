using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface ILoanRepository
    {
        
        void Create (Loan loan);
        LoanDto GetById (int id);
        Loan GetByIdReturningLoanObject (int id);
        List<LoanDto> GetAll();
    }
}