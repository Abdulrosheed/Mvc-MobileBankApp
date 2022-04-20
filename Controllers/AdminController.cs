using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileBankApp.Interfaces;
using MobileBankApp.Models.Dtos;

namespace MobileBankApp.Controllers
{
  
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View(_adminService.GetAll());
        }
        public IActionResult Details(int id)
        {
            var admin = _adminService.GetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(admin);
        }
        public IActionResult Update(int id)
        {
            var admin = _adminService.GetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            if (admin == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]

        public IActionResult Update(UpdateAdminRequestModel model , int id)
        {
            _adminService.Update(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value), model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete (int id)
        {
            var admin = _adminService.GetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _adminService.Delete(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return RedirectToAction ("Index");
        }
        
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Create (CreateAdminRequestModel model)
        {
            if (!_adminService.ExistsByEmail(model.Email) && !_adminService.ExistsByPhoneNumber(model.PhoneNumber))
            {
                _adminService.Register(model);
                return RedirectToAction("Profile");
            }
            else
            {
                ViewBag.Error = "Invalid Email or PassWord";
                return View();
            }
            
        
           
        }
        public IActionResult Login ()
        {
            return View();
        }
        public IActionResult Profile ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginAdmin login)
        {
            if( _adminService.ExistsByEmail(login.Email) )
            {
               var admin = _adminService.Login(login);
               var claims = new List<Claim>
               {
                   new Claim (ClaimTypes.NameIdentifier , admin.Id.ToString()),
                   new Claim (ClaimTypes.Role , "Admin"),

               }; 
               
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Profile");
            }
            else
            {
                
                ViewBag.Error = "Invalid Email or PassWord";
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