using System.Collections.Generic;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ICustomerRepository _customerRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository , ICustomerRepository customerRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _customerRepository = customerRepository;
        }

        public void Create(CreateSubscriptionRequestModel model)
        {
            var customer =  _customerRepository.GetByPinReturningObj(model.Pin);
            if (customer.Balance > (model.Amount + 10))
            {
                customer.Balance -= model.Amount;
                var sub = new Subscription
                {
                    DateCreated = System.DateTime.UtcNow,
                    Amount = model.Amount,
                    CustomerId = customer.Id,
                    SubscriptionType = model.SubscriptionType,
                    Pin = model.Pin,

                };
                _subscriptionRepository.Create(sub);
            }
            
        }

        public List<SubscriptionDto> GetAll()
        {
            return _subscriptionRepository.GetAll();
        }

        public SubscriptionDto GetById(int id)
        {
            return _subscriptionRepository.GetById(id);
        }
    }
}