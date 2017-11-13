using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetPizza.Models;
using DotNetPizza.Models.Repository;
using DotNetPizza.Models.PizzaViewModel;

namespace DotNetPizza.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Pizza> fakeRepo;

        public HomeController(IRepository<Pizza> repository)
        {
            fakeRepo = repository;
        }
        public IActionResult Index()
        {
            List<PizzaViewModel> pizzasVM = new List<PizzaViewModel>();

            fakeRepo.GetAll.ToList().ForEach(p =>
            {
                PizzaViewModel pizzaVM = new PizzaViewModel
                {
                    PizzaID = p.PizzaID,
                    Title = p.Title,
                    Description = p.Description,
                    PriceHT = p.Price,
                    Image = p.Image
                };

                pizzasVM.Add(pizzaVM);
            });

            return View(pizzasVM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
