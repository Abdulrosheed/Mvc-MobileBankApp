using System;
using System.ComponentModel.DataAnnotations;

namespace MobileBankApp.Models.Dtos
{
    public class TransactionDto
    {
        public int Id{get;set;}
        public string Description {get;set;}
        public int CustomerId{get;set;}
        public decimal Amount{get;set;}
        public string RecipentAccountNumber{get;set;}
        public string AccountNumber{get;set;}
        public DateTime DateCreated {get;set;}
    }
    public class CreateWithdrawAndDepositTransactionModel
    {
         [Required]
         [DataType(DataType.Password)]
        public string Pin {get;set;}
        public decimal Amount {get;set;}
        public string Description {get;set;}
        
        
    }
    public class CreateTransferTransactionModel
    {
        [Required]
         [DataType(DataType.Password)] 
        public string Pin {get;set;}
        public decimal Amount {get;set;}
        public string RecipentAccountNumber{get;set;}
        public string Description {get;set;}
        
        
    }
}