using System.Collections.Generic;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Interfaces
{
    public interface ISubscriptionService
    {
        void Create (CreateSubscriptionRequestModel model);
    
        SubscriptionDto GetById (int id);
        List<SubscriptionDto> GetAll();
    }
}