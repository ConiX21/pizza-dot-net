using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll { get; }

        T GetOne(int id);

        Task<T> CreateAsync(T obj);
    }
}
