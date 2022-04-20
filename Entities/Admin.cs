using System;
using MobileBankApp.Enum;

namespace MobileBankApp.Entities
{
    public class Admin
    {
        
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Address {get;set;}
    
        public int Age {get;set;}
        public GenderType Gender {get;set;}
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public string PassWord {get;set;}
        public DateTime DateCreated {get;set;}
    }
}