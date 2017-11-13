using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models.Repository
{
    public interface ICreatable<T>
    {
        T Create(T obj);
    }
}
