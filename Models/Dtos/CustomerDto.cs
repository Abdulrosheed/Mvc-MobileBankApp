using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MobileBankApp.Enum;

namespace MobileBankApp.Models.Dtos
{
    public class CustomerDto
    {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Address {get;set;}
        public DateTime DateOfBirth {get;set;}
        public string AccountNumber {get;set;}
        public string AccountName {get;set;}
        public GenderType Gender {get;set;}
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public decimal Balance {get;set;}
        public decimal AmountToBePaid {get;set;}
        
        public List<TransactionDto> Transactions {get;set;} = new List<TransactionDto>();
        public List<LoanDto> Loans {get;set;} = new List<LoanDto>();
    }
    public class UpdateCustomerRequestModel
    {
        
        public GenderType Gender {get;set;}
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public string AccountName {get;set;}
        
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Address {get;set;}
    
    }
    public class CreateCustomerRequestModel
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
        public string AccountName {get;set;}
         [Required]
        public string FirstName {get;set;}
         [Required]
        public string LastName {get;set;}
        [Required]
        public string Address {get;set;}
         [Required]
        public DateTime DateOfBirth {get;set;}
         [Required]
         [MaxLength(10)]
         [MinLength(5)]
         [DataType(DataType.Password)]
        public string Pin {get;set;}
    }
    public class Login
    {
       
        [Required]
        public string Email {get;set;}
       
         [Required]
         [DataType(DataType.Password)]
        public string Pin {get;set;}
        

    }
    
}