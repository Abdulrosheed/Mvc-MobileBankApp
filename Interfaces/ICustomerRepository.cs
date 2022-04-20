using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface ICustomerRepository
    {
        void Create (Customer customer);
        void Delete (Customer customer);
        void Update (Customer customer);
        CustomerDto GetById (int id);
        Customer GetByIdReturningCustomerObject (int id);
        Customer GetByAccountNumberReturningCustomerObject (string accountNumber);
        CustomerDto GetByPin(string pin);
        Customer GetByPinReturningObj(string pin);
    
        List<CustomerDto> GetAll();
        bool ExistsByAccountName (string accountName);
        bool ExistsByAccountNumber (string accountNumber);
        bool ExistsByPin (string pin);
        bool ExistsByPhoneNumber (string phoneNumber);
        bool ExistsByEmail (string email);
    }
}