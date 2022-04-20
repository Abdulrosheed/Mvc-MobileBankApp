using Microsoft.AspNetCore.Mvc;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly ICustomerService _customerService;

        public LoanController(ILoanService loanService , ICustomerService customerService)
        {
            _loanService = loanService;
            _customerService = customerService;
        }
        public IActionResult Index ()
        {
            return View (_loanService.GetAll());
        }
        public IActionResult Create ()
        {
            return View ();
        }
        [HttpPost]
        public IActionResult Create (CreateLoanRequestModel model)
        {
            if (_customerService.ExistsByPin(model.Pin))
            {
                _loanService.Create(model);
                return RedirectToAction ("Sucess");
            }
            else
            {
                ViewBag.Error = "Invalid pin";
                return View();
            }
        }
        public IActionResult Details(int id)
        
        {
            var loan = _loanService.GetById(id);
            if (loan != null)
            {
                return View (loan);
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