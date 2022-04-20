using System.Collections.Generic;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface ILoanService
    {
        void Create (CreateLoanRequestModel model);
    
        LoanDto GetById (int id);
        List<LoanDto> GetAll();
    }
}