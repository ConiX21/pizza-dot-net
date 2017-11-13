using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public PizzaViewModel.PizzaViewModel PizzaVm { get; set; }
        public int Quantity { get; set; }
    }
}
