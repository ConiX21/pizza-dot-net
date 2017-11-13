using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetPizza.Models;
using Microsoft.AspNetCore.Identity;

namespace DotNetPizza.Controllers
{
    public class OrderController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;
        public OrderController(SignInManager<ApplicationUser> SignInManager)
        {
            _signInManager = SignInManager;
        }

        public IActionResult Checkout()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View(new Order());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

    }
}