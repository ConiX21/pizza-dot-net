using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetPizza.Infrastructure;

namespace DotNetPizza.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session; return cart;
        }
        [JsonIgnore] public ISession Session { get; set; }
        public override void AddItem(PizzaViewModel.PizzaViewModel pizzaVM, int quantity)
        {
            base.AddItem(pizzaVM, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(PizzaViewModel.PizzaViewModel pizzaVM)
        {
            base.RemoveLine(pizzaVM);
            Session.SetJson("Cart", this);
        }
        public override void Clear() { base.Clear(); Session.Remove("Cart"); }
    }
}
