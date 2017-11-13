using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetPizza.Models.Repository;
using DotNetPizza.Models;
using DotNetPizza.Infrastructure;
using DotNetPizza.Models.CartViewModel;
using DotNetPizza.Models.PizzaViewModel;

namespace DotNetPizza.Controllers
{
    public class CartController : Controller
    {
        private IRepository<Pizza> repository;
        private Cart _cart;

        public CartController(IRepository<Pizza> repo, Cart cartService) {
            repository = repo;
            _cart = cartService;
        }
        public RedirectToActionResult AddToCart(int pizzaID, string returnUrl)
        {
            Pizza pizza = repository.GetOne(pizzaID);

            PizzaViewModel pizzaVM = new PizzaViewModel
            {
                PizzaID = pizza.PizzaID,
                Title = pizza.Title,
                Description = pizza.Description,
                PriceHT = pizza.Price,
                Image = pizza.Image
            };

            if (pizza != null)
            {
                _cart.AddItem(pizzaVM, 1);
            }

            return RedirectToAction("Index", new
            {
                returnUrl
            });
        }

        public RedirectToActionResult RemoveFromCart(int PizzaID, string returnUrl)
        {
            Pizza pizza = repository.GetOne(PizzaID);
            PizzaViewModel pizzaVM = new PizzaViewModel
            {
                PizzaID = pizza.PizzaID,
                Title = pizza.Title,
                Description = pizza.Description,
                PriceHT = pizza.Price,
                Image = pizza.Image
            };

            if (pizza != null)
            {
                _cart.RemoveLine(pizzaVM);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart() {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart(); 
            return cart;
        }

        private void SaveCart(Cart cart) {
            HttpContext.Session.SetJson("Cart", cart);
        }

        public ViewResult Index(string returnUrl) {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }


    }
}
