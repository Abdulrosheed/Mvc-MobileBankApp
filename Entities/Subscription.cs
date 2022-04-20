using System;

namespace MobileBankApp.Entities
{
    public class Subscription
    {
        public int Id {get;set;}
        public int CustomerId {get;set;}
        public Customer Customer {get;set;}
        public decimal Amount {get;set;}
        public DateTime DateCreated {get;set;}
        public string Pin {get;set;}
        public SubscriptionType SubscriptionType {get;set;}
    }
}