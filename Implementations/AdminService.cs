using System;
using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository  _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public void Delete(int id)
        {
            var admin = _adminRepository.GetByIdReturningAdminObject(id);
            _adminRepository.Delete(admin);
        }

        public bool ExistsByEmail(string email)
        {
            return _adminRepository.ExistsByEmail(email);
        }

        public bool ExistsByPhoneNumber(string phoneNumber)
        {
            return _adminRepository.ExistsByPhoneNumber(phoneNumber);
        }

        public List<AdminDto> GetAll()
        {
            return _adminRepository.GetAll();
        }

        public AdminDto GetById(int id)
        {
            return _adminRepository.GetById(id);
        }

        public AdminDto Login(LoginAdmin login)
        {
            var admin = _adminRepository.GetByEmailReturningAdminObject(login.Email);
            return new AdminDto 
            {
                Id = admin.Id,
             
            };
        }

        public void Register(CreateAdminRequestModel model)
        {
            var admin = new Admin
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = DateTime.Now.Year - model.DateOfBirth.Year,
                Address = model.Address,
                Email = model.Email,
                Gender = model.Gender,
                MaritalStatus = model.MaritalStatus,
                PhoneNumber = model.PhoneNumber,
                PassWord = model.PassWord,
                DateCreated = DateTime.Now,
            };
            _adminRepository.Create(admin);
        }

        public void Update(int id, UpdateAdminRequestModel model)
        {
            var admin = _adminRepository.GetByIdReturningAdminObject(id);
            admin.Email = model.Email ?? admin.Email;
            admin.FirstName = model.FirstName ?? admin.FirstName;
            admin.LastName = model.LastName ?? admin.LastName;
            admin.PhoneNumber = model.PhoneNumber ?? admin.PhoneNumber;
            admin.Address = model.Address ?? admin.Address;
            if (model.Gender != 0 )admin.Gender = model.Gender;
            if (model.MaritalStatus != 0 )admin.MaritalStatus = model.MaritalStatus;
            
            _adminRepository.Update(admin);
        }
    }
}