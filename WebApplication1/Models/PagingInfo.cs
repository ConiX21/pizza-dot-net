using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models
{
    public class PagingInfo
    {
        public int ProductPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        
    }
}
