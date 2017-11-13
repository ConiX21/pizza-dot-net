using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models.Repository
{
    public class FakeRepositoryPizza : IRepository<Pizza>
    {
        private List<Pizza> _Pizzas { get; set; } = new List<Pizza>
        {
            new Pizza{ PizzaID = 1, Title = "Reine", Description = "Verum ad istam omnem orationem brevis est defensio. Nam quoad aetas M. Caeli dare potuit isti suspicioni locum, fuit primum ipsius pudore, deinde etiam patris diligentia disciplinaque munita. Qui ut huic virilem togam deditšnihil dicam hoc loco de me; tantum sit, quantum vos existimatis; hoc dicam, hunc a patre continuo ad me esse deductum; nemo hunc M. Caelium in illo aetatis flore vidit nisi aut cum patre aut mecum aut in M. Crassi castissima domo, cum artibus honestissimis erudiretur.", Image = "dotnet_pizza_Home.jpg", Price = 10.50m},
            new Pizza{ PizzaID = 2, Title = "4 fromages", Description = "Verum ad istam omnem orationem brevis est defensio. Nam quoad aetas M. Caeli dare potuit isti suspicioni locum, fuit primum ipsius pudore, deinde etiam patris diligentia disciplinaque munita. Qui ut huic virilem togam deditšnihil dicam hoc loco de me; tantum sit, quantum vos existimatis; hoc dicam, hunc a patre continuo ad me esse deductum; nemo hunc M. Caelium in illo aetatis flore vidit nisi aut cum patre aut mecum aut in M. Crassi castissima domo, cum artibus honestissimis erudiretur.", Image = "dotnet_pizza_Home_2.jpg", Price = 11.50m},
            new Pizza{ PizzaID = 3, Title = "Chorizo", Description = "Verum ad istam omnem orationem brevis est defensio. Nam quoad aetas M. Caeli dare potuit isti suspicioni locum, fuit primum ipsius pudore, deinde etiam patris diligentia disciplinaque munita. Qui ut huic virilem togam deditšnihil dicam hoc loco de me; tantum sit, quantum vos existimatis; hoc dicam, hunc a patre continuo ad me esse deductum; nemo hunc M. Caelium in illo aetatis flore vidit nisi aut cum patre aut mecum aut in M. Crassi castissima domo, cum artibus honestissimis erudiretur.", Image = "dotnet_pizza_Home_3.jpg", Price = 10.00m},
            new Pizza{ PizzaID = 4, Title = "Anchois", Description = "Verum ad istam omnem orationem brevis est defensio. Nam quoad aetas M. Caeli dare potuit isti suspicioni locum, fuit primum ipsius pudore, deinde etiam patris diligentia disciplinaque munita. Qui ut huic virilem togam deditšnihil dicam hoc loco de me; tantum sit, quantum vos existimatis; hoc dicam, hunc a patre continuo ad me esse deductum; nemo hunc M. Caelium in illo aetatis flore vidit nisi aut cum patre aut mecum aut in M. Crassi castissima domo, cum artibus honestissimis erudiretur.", Image = "dotnet_pizza_Home_4.jpg", Price = 9.00m}
        };

        public IQueryable<Pizza> GetAll => _Pizzas.AsQueryable<Pizza>();

        public Pizza GetOne(int id)
        {
            return _Pizzas.FirstOrDefault(p => p.PizzaID == id);
        }

        public Pizza Create(Pizza obj)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> CreateAsync(Pizza obj)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<Pizza> GetAll => new List<Pizza>
        //{
        //    new Pizza{ PizzaID = 1, Title = "Reine", Description = "Verum ad istam omnem orationem brevis est defensio. Nam quoad aetas M. Caeli dare potuit isti suspicioni locum, fuit primum ipsius pudore, deinde etiam patris diligentia disciplinaque munita. Qui ut huic virilem togam deditšnihil dicam hoc loco de me; tantum sit, quantum vos existimatis; hoc dicam, hunc a patre continuo ad me esse deductum; nemo hunc M. Caelium in illo aetatis flore vidit nisi aut cum patre aut mecum aut in M. Crassi castissima domo, cum artibus honestissimis erudiretur.", Image = "dotnet_pizza_Home.jpg", Price = 10.50m},
        //    new Pizza{ PizzaID = 2, Title = "4 fromages", Description = "Verum ad istam omnem orationem brevis est defensio. Nam quoad aetas M. Caeli dare potuit isti suspicioni locum, fuit primum ipsius pudore, deinde etiam patris diligentia disciplinaque munita. Qui ut huic virilem togam deditšnihil dicam hoc loco de me; tantum sit, quantum vos existimatis; hoc dicam, hunc a patre continuo ad me esse deductum; nemo hunc M. Caelium in illo aetatis flore vidit nisi aut cum patre aut mecum aut in M. Crassi castissima domo, cum artibus honestissimis erudiretur.", Image = "dotnet_pizza_Home_2.jpg", Price = 11.50m},
        //    new Pizza{ PizzaID = 3, Title = "Chorizo", Description = "Verum ad istam omnem orationem brevis est defensio. Nam quoad aetas M. Caeli dare potuit isti suspicioni locum, fuit primum ipsius pudore, deinde etiam patris diligentia disciplinaque munita. Qui ut huic virilem togam deditšnihil dicam hoc loco de me; tantum sit, quantum vos existimatis; hoc dicam, hunc a patre continuo ad me esse deductum; nemo hunc M. Caelium in illo aetatis flore vidit nisi aut cum patre aut mecum aut in M. Crassi castissima domo, cum artibus honestissimis erudiretur.", Image = "dotnet_pizza_Home_3.jpg", Price = 10.00m},
        //    new Pizza{ PizzaID = 4, Title = "Anchois", Description = "Verum ad istam omnem orationem brevis est defensio. Nam quoad aetas M. Caeli dare potuit isti suspicioni locum, fuit primum ipsius pudore, deinde etiam patris diligentia disciplinaque munita. Qui ut huic virilem togam deditšnihil dicam hoc loco de me; tantum sit, quantum vos existimatis; hoc dicam, hunc a patre continuo ad me esse deductum; nemo hunc M. Caelium in illo aetatis flore vidit nisi aut cum patre aut mecum aut in M. Crassi castissima domo, cum artibus honestissimis erudiretur.", Image = "dotnet_pizza_Home_4.jpg", Price = 9.00m}
        //}.AsQueryable<Pizza>();
    }

    //PagingInfo = new PagingInfo {
        //                CurrentPage = productPage,
        //                ItemsPerPage = PageSize,
        //                TotalItems = repository.Products.Count()
        //            }
}
