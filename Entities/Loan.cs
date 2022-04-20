using System;

namespace MobileBankApp.Entities
{
    public class Loan
    {
        public int Id{get;set;}
        public int CustomerId{get;set;}
        public Customer Customer {get;set;}
        public decimal Amount{get;set;}
        
        public string Pin{get;set;}
        public string AccountNumber{get;set;}
        public DateTime DateCreated {get;set;}
    }
}