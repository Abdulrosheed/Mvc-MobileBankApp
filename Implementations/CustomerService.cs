using System;
using System.Collections.Generic;
using System.Linq;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;    

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Delete(int id)
        {
            var customer = _customerRepository.GetByIdReturningCustomerObject(id);
            _customerRepository.Delete(customer);
        }

        public bool ExistsByAccountName(string accountName)
        {
            return _customerRepository.ExistsByAccountName(accountName);
        }

        public bool ExistsByAccountNumber(string accountNumber)
        {
            return _customerRepository.ExistsByAccountNumber(accountNumber);
        }

        public bool ExistsByEmail(string email)
        {
            return _customerRepository.ExistsByEmail(email);
        }

        public bool ExistsByPhoneNumber(string phoneNumber)
        {
            return _customerRepository.ExistsByPhoneNumber(phoneNumber);
        }

        public bool ExistsByPin(string pin)
        {
            return _customerRepository.ExistsByPin(pin);
        }

        public List<CustomerDto> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public CustomerDto GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public CustomerDto GetByPin(string pin)
        {
            return _customerRepository.GetByPin(pin);
        }

   

        public CustomerDto Login(Login login)
        {
            var customer = _customerRepository.GetByPinReturningObj(login.Pin);
            return new CustomerDto
            {
                Id = customer.Id,
                Email = customer.Email,
               
            };
        }

        public void Register(CreateCustomerRequestModel model)
        {
            var customer = new Customer
            {
                AccountName = model.AccountName,
                AccountNumber = Guid.NewGuid().ToString().Substring(0,10).Replace("-" , "").ToUpper(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                Email = model.Email,
                Gender = model.Gender,
                MaritalStatus = model.MaritalStatus,
                PhoneNumber = model.PhoneNumber,
                Pin = model.Pin,
                Balance = 0,
                AmountToBePaid = 0,
                DateCreated = DateTime.Now,
            };
            _customerRepository.Create(customer);
        }

        public void Update(int id, UpdateCustomerRequestModel model)
        {
            var customer = _customerRepository.GetByIdReturningCustomerObject(id);
            customer.Email = model.Email ?? customer.Email;
            customer.FirstName = model.FirstName ?? customer.FirstName;
            customer.LastName = model.LastName ?? customer.LastName;
            customer.PhoneNumber = model.PhoneNumber ?? customer.PhoneNumber;
            customer.Address = model.Address ?? customer.Address;
            if (model.Gender != 0 )customer.Gender = model.Gender;
            if (model.MaritalStatus != 0 )customer.MaritalStatus = model.MaritalStatus;
            customer.AccountName = model.AccountName ?? customer.AccountName;
            _customerRepository.Update(customer);
            
        }

    }
}