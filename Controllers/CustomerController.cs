using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp
{
    public class CustomerController : Controller
    {
        
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
    
        public IActionResult Index()
        {
            return View(_customerService.GetAll());
        }
        public IActionResult Details(int id)
        {
            var customer = _customerService.GetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(customer);
        }
        
        public IActionResult Update(int id)
        {
            var customer = _customerService.GetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        
        public IActionResult Update(UpdateCustomerRequestModel model , int id)
        {
            _customerService.Update(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value), model);
            return RedirectToAction("Profile");
        }
    
        public IActionResult Delete (int id)
        {
            var customer = _customerService.GetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost , ActionName("Delete")]
        
        public IActionResult DeleteConfirmed(int id)
        {
            _customerService.Delete(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return RedirectToAction ("Index");
        }
        
        public IActionResult Profile ()
        {
            return View();
        }
        
        public IActionResult Create ()
        {
            return View();
        }
       
        [HttpPost]
        
        public IActionResult Create (CreateCustomerRequestModel model)
        {
            
            if (!_customerService.ExistsByPin(model.Pin))
            {
                _customerService.Register(model);
                return RedirectToAction("Index" , "Home");
            }
            else
            {
        
                ViewBag.Error = "Pls Enter a Strong Pin";
                return View();
            }
        
           
        }
        

        public IActionResult Login ()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Login(Login login)
        {
            if( _customerService.ExistsByPin(login.Pin))
            {
               var customer = _customerService.Login(login);
               var claims = new List<Claim>
               {
                   new Claim (ClaimTypes.NameIdentifier , customer.Id.ToString()),
                   new Claim (ClaimTypes.Email , customer.Email),
                   new Claim (ClaimTypes.Role , "Customer"),

               }; 
               
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Profile");
            }
            else
            {
                ViewBag.Error = "Invalid Email or Pin";
                return View();
            }
        }
    
        public IActionResult LogOut()
        {
            
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index" , "Home");
        }
    }
}