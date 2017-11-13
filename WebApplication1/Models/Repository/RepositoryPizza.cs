using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetPizza.Data;

namespace DotNetPizza.Models.Repository
{
    public class RepositoryPizza : IRepository<Pizza>
    {
        DotNetPizzaDbContext context;

        public RepositoryPizza(DotNetPizzaDbContext dataContext)
        {
            context = dataContext;
        }
        
        public IQueryable<Pizza> GetAll => context.Set<Pizza>();

        public async Task<Pizza> CreateAsync(Pizza obj)
        {
            context.Pizza.Add(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public Pizza GetOne(int id)
        {
            return context.Pizza.Find(id);
        }
    }
}
