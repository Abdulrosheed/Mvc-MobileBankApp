using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface ISubscriptionRepository
    {
          void Create (Subscription subscription);
        SubscriptionDto GetById (int id);
        Subscription GetByIdReturningLoanObject (int id);
        List<SubscriptionDto> GetAll();
    }
}