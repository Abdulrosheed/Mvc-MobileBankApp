using System;
using System.ComponentModel.DataAnnotations;

namespace MobileBankApp.Models.Dtos
{
    public class SubscriptionDto
    {
        public int Id{get;set;}
        
        public decimal Amount{get;set;}
        public SubscriptionType SubscriptionType {get;set;}
        public DateTime DateCreated {get;set;}
    }
    public class CreateSubscriptionRequestModel
    {
        public string PhoneNumber {get;set;}
        public string MeterNumber {get;set;}
        public string SmartCardCode {get;set;}
        public decimal Amount{get;set;}
         [Required]
         [DataType(DataType.Password)]
        public string Pin {get;set;}
        public SubscriptionType SubscriptionType {get;set;}
    }
}