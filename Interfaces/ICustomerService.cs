using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface ICustomerService
    {
        void Register (CreateCustomerRequestModel model);
        void Delete (int id);
        void Update (int id , UpdateCustomerRequestModel model);
        CustomerDto GetById (int id);
        CustomerDto GetByPin (string pin);
        
        
        CustomerDto Login (Login login);
        List<CustomerDto> GetAll();
        bool ExistsByAccountName (string accountName);
        bool ExistsByAccountNumber (string accountNumber);
        bool ExistsByPin (string pin);
        bool ExistsByPhoneNumber (string phoneNumber);
        bool ExistsByEmail (string email);

    }
}