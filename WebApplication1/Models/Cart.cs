using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetPizza.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(PizzaViewModel.PizzaViewModel pizzaVM, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.PizzaVm.PizzaID == pizzaVM.PizzaID).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { PizzaVm = pizzaVM, Quantity = quantity });
            }
            else { line.Quantity += quantity; }
        }

        public virtual void RemoveLine(PizzaViewModel.PizzaViewModel pizza){
            lineCollection.RemoveAll(l => l.PizzaVm.PizzaID == pizza.PizzaID);
        }

        public virtual decimal ComputeTotalValue() => lineCollection.Sum(e => e.PizzaVm.PriceTTC() * e.Quantity);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
}