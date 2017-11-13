using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetPizza.Models.Repository;
using DotNetPizza.Models;
using DotNetPizza.Models.PizzaViewModel;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DotNetPizza.Controllers
{
    public class PizzaController : Controller
    {
        IRepository<Pizza> fakeRepo;

        public PizzaController(IRepository<Pizza> repository)
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

        //[Route("[controller]/[action]/{id:int}")]
        public PartialViewResult Detail(int id)
        {
            PizzaViewModel pizzasVM = new PizzaViewModel();
            var pizza = fakeRepo.GetOne(id);

            PizzaViewModel pizzaVM = new PizzaViewModel
            {
                PizzaID = pizza.PizzaID,
                Title = pizza.Title,
                Description = pizza.Description,
                PriceHT = pizza.Price,
                Image = pizza.Image
            };

            return PartialView("PizzaDetailPartial", pizzaVM);
        }

        
    }
}