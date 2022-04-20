using System;
using System.ComponentModel.DataAnnotations;

namespace MobileBankApp.Models.Dtos
{
    public class LoanDto
    {
        public int Id{get;set;}
        public int CustomerId{get;set;}
        public decimal Amount{get;set;}
        public string AccountNumber{get;set;}
        public string Name {get;set;}
        public DateTime DateCreated {get;set;}
    }
    public class CreateLoanRequestModel
    {
        public string AccountNumber {get;set;}
         [Required]
         [DataType(DataType.Password)]
        public string Pin {get;set;}
        public decimal Amount {get;set;}
        
        
        
    }
    
}