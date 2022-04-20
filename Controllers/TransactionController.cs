using Microsoft.AspNetCore.Mvc;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ICustomerService _customerService;
        public TransactionController(ITransactionService transactionService , ICustomerService customerService)
        {
            _transactionService = transactionService;
            _customerService = customerService;
        }
        public IActionResult Withdraw()
        {
            return View();
        }
         public IActionResult WithdrawSucess()
        {
            return View();
        }
         public IActionResult DepositSucess()
        {
            return View();
        }
         public IActionResult TransferSucess()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Withdraw(CreateWithdrawAndDepositTransactionModel model)
        {   if (_customerService.ExistsByPin(model.Pin))
            {
                var customer = _customerService.GetByPin(model.Pin);
                var x = (customer.Balance - (model.Amount + 10));
                var y = ((model.Amount + 10) - customer.Balance);
                if (x >= y && _customerService.ExistsByPin(model.Pin))
                {
                    model.Description = "Withdraw";
                    
                    _transactionService.Create(model);
                    return RedirectToAction("WithdrawSucess" );
                }
                 ViewBag.Error = "You dont have sufficient balance to complete this transaction ";
                return View();
            }
            
            else
            {
                ViewBag.Error = "You dont have sufficient balance to complete this transaction ";
                return View();
            }
           
        }
       
          public IActionResult Deposit()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Deposit(CreateWithdrawAndDepositTransactionModel model)
        {
            if(_customerService.ExistsByPin(model.Pin))
            {
                
                model.Description = "Deposit";
                _transactionService.Create(model);
                return RedirectToAction("DepositSucess");
            }
            else
            {
                
                ViewBag.Error = " Incorrect pin ";
                return View();
            }
        }
          public IActionResult Transfer()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Transfer(CreateTransferTransactionModel model)
        {
            if(_customerService.ExistsByPin(model.Pin) && _customerService.ExistsByAccountNumber(model.RecipentAccountNumber))
            {         
                var customer = _customerService.GetByPin(model.Pin);
                var x = (customer.Balance - (model.Amount + 10));
                var y = ((model.Amount + 10) - customer.Balance);
                if (x >= y && _customerService.ExistsByPin(model.Pin) )
                {
                    model.Description = "Transfer";
                    
                    _transactionService.Create(model);
                    return RedirectToAction("TransferSucess");
                }
                 ViewBag.Error = "You dont have sufficient balance to complete this transaction ";
                return View();
            }
            else
            {
                ViewBag.Error = "You dont have sufficient balance to complete this transaction or Invalid Benefactor Account Number";
                return View();
            }
         
            

        }
    }
}