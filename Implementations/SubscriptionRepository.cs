using System.Collections.Generic;
using System.Linq;
using MobileBankApp.Context;
using MobileBankApp.Entities;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Implementations
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly MobileAppBankDbContext _context;

        public SubscriptionRepository(MobileAppBankDbContext context)
        {
            _context = context;
        }
        public void Create(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();
        }

        public List<SubscriptionDto> GetAll()
        {
            return _context.Subscriptions.Select(a => new SubscriptionDto 
            {
                DateCreated = a.DateCreated,
                Id = a.Id,
                Amount = a.Amount,
                SubscriptionType = a.SubscriptionType

            }).ToList();
        }

        public SubscriptionDto GetById(int id)
        {
            var sub = _context.Subscriptions.Find(id);
            return new SubscriptionDto 
            {
                DateCreated = sub.DateCreated,
                Id = sub.Id,
                Amount = sub.Amount,
                SubscriptionType = sub.SubscriptionType
            };
        }

        public Subscription GetByIdReturningLoanObject(int id)
        {
            return _context.Subscriptions.Find(id);
        }
    }
}