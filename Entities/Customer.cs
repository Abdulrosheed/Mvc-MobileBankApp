using System;
using System.Collections.Generic;
using MobileBankApp.Enum;

namespace MobileBankApp.Entities
{
    public class Customer
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
        public string Pin {get;set;}
        public decimal Balance {get;set;}
        public decimal AmountToBePaid{get;set;}
        public DateTime DateCreated {get;set;}
        public List<Transaction> Transactions {get;set;} = new List<Transaction>();
        public List<Loan> Loans {get;set;} = new List<Loan>();
        public List<Subscription> Subscriptions {get;set;} = new List<Subscription>();
    }
}