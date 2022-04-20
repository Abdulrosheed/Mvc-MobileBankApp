using System;
using System.Collections.Generic;
using System.Linq;
using MobileBankApp.Context;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MobileAppBankDbContext _context;

        public AdminRepository(MobileAppBankDbContext context)
        {
            _context = context;
        }

        public void Create(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public void Delete(Admin admin)
        {
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }

        public bool ExistsByEmail(string email)
        {
            return _context.Admins.Any(a => a.Email == email);

        }

        public bool ExistsByPhoneNumber(string phoneNumber)
        {
          return _context.Admins.Any(a => a.PhoneNumber == phoneNumber);  
        }

        public List<AdminDto> GetAll()
        {
            return _context.Admins.Select(a => new AdminDto
            {
                
                Id = a.Id,
                Name = $"{a.FirstName} {a.LastName}",
                Address = a.Address,
                Age = a.Age ,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
                Gender = a.Gender,
                MaritalStatus = a.MaritalStatus

            }).ToList();
        }

        public Admin GetByEmailReturningAdminObject(string email)
        {
            return _context.Admins.SingleOrDefault(a => a.Email == email);
        }

        public AdminDto GetById(int id)
        {
            var admin  = _context.Admins.SingleOrDefault(a => a.Id == id);
            return new AdminDto 
            {
                
                Name = $"{admin.FirstName} {admin.LastName}",
                Address = admin.Address,
                
                Gender = admin.Gender,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                MaritalStatus = admin.MaritalStatus,
            };
        }

        public Admin GetByIdReturningAdminObject(int id)
        {
            return _context.Admins.SingleOrDefault(a => a.Id == id);
        }

        public void Update(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }
    }
}