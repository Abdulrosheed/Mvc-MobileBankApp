using System;
using System.ComponentModel.DataAnnotations;
using MobileBankApp.Enum;

namespace MobileBankApp.Models.Dtos
{
    public class AdminDto
    {
        public int Id {get;set;}
        
        public string Name {get;set;}
        public string Address {get;set;}
        public int Age {get;set;}
        public GenderType Gender {get;set;}
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
    }
      public class UpdateAdminRequestModel
    {
        
        public GenderType Gender {get;set;}
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Address {get;set;}
    }
        public class CreateAdminRequestModel
    {
        [Required]
        public GenderType Gender {get;set;}
        [Required] 
        public MaritalStatusType MaritalStatus {get;set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber {get;set;}
        
         [Required]
        public string FirstName {get;set;}
         [Required]
        public string LastName {get;set;}
        [Required]
        public string Address {get;set;}
         [Required]
        public DateTime DateOfBirth {get;set;}
        public string PassWord {get;set;}
        
    }
    public class LoginAdmin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {get;set;}
       [Required]
         [DataType(DataType.Password)]
       public string PassWord {get;set;}
         [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber {get;set;}
        

    }
}