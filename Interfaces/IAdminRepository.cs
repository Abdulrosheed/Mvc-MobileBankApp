using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface IAdminRepository
    {
         
        void Create (Admin Admin);
        void Delete (Admin admin);
        void Update (Admin admin);
        AdminDto GetById (int id);
        Admin GetByIdReturningAdminObject (int id);
        Admin GetByEmailReturningAdminObject (string email);
        List <AdminDto> GetAll ();
        bool ExistsByPhoneNumber (string phoneNumber);
        bool ExistsByEmail (string email);
    }
}