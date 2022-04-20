using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface IAdminService
    {
        void Register (CreateAdminRequestModel model);
        void Delete (int id);
        void Update (int id , UpdateAdminRequestModel model);
        AdminDto GetById (int id);
        AdminDto Login (LoginAdmin login);
        List<AdminDto> GetAll();
        bool ExistsByPhoneNumber (string phoneNumber);
        bool ExistsByEmail (string email);
    }
}