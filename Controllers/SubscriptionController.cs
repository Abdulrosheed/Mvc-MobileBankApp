using Microsoft.AspNetCore.Mvc;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly ICustomerService _customerService;

        public SubscriptionController(ISubscriptionService subscriptionService , ICustomerService customerService)
        {
            _subscriptionService = subscriptionService;
            _customerService = customerService;
        }
        public IActionResult Index ()
        {
            return View (_subscriptionService.GetAll());
        }
        public IActionResult CreateAirtime ()
        {
            return View ();
        }
        [HttpPost]
        public IActionResult CreateAirtime (CreateSubscriptionRequestModel model)
        {
           model.SubscriptionType = MobileBankApp.SubscriptionType.Airtime;
            if (_customerService.ExistsByPin(model.Pin))
            {
                 var customer = _customerService.GetByPin(model.Pin);
                 var y = (model.Amount + 10) - customer.Balance;
                 var x = customer.Balance - (model.Amount +10);
                if (x >= y)
                {
                    _subscriptionService.Create(model);
                    return RedirectToAction ("Sucess");
                }
                ViewBag.Error = "You dont have sufficient balance";
                return View();
            }
            else
            {
                ViewBag.Error = "Invalid pin";
                return View();
            }
        }
              public IActionResult CreateNepaBill ()
        {
            return View ();
        }
        [HttpPost]
        public IActionResult CreateNepaBill (CreateSubscriptionRequestModel model)
        {
           model.SubscriptionType = MobileBankApp.SubscriptionType.NepaBills;
            if (_customerService.ExistsByPin(model.Pin))
            {
                 var customer = _customerService.GetByPin(model.Pin);
                 var y = (model.Amount + 10) - customer.Balance;
                 var x = customer.Balance - (model.Amount +10);
                if (x >= y)
                {
                    _subscriptionService.Create(model);
                    return RedirectToAction ("Sucess");
                }
                ViewBag.Error = "You dont have sufficient balance";
                return View();
            }
            else
            {
                ViewBag.Error = "Invalid pin";
                return View();
            }
        }
              public IActionResult CreateDecoder ()
        {
            return View ();
        }
        [HttpPost]
        public IActionResult CreateDecoder (CreateSubscriptionRequestModel model)
        {
           model.SubscriptionType = MobileBankApp.SubscriptionType.Decoder;
            if (_customerService.ExistsByPin(model.Pin))
            {
                 var customer = _customerService.GetByPin(model.Pin);
                 var y = (model.Amount + 10) - customer.Balance;
                 var x = customer.Balance - (model.Amount +10);
                if (x >= y)
                {
                    _subscriptionService.Create(model);
                    return RedirectToAction ("Sucess");
                }
                ViewBag.Error = "You dont have sufficient balance";
                return View();
            }
            else
            {
                ViewBag.Error = "Invalid pin";
                return View();
            }
        }
        public IActionResult Details(int id)
        
        {
            var sub = _subscriptionService.GetById(id);
            if (sub != null)
            {
                return View (sub);
            }
            else {
                return NotFound();
            }
        }
         public IActionResult Sucess()
        {
            return View();
        }
    }
}