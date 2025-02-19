using Lojaback.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojaback.Domain.Model
{
     public class Product : IModel
    {
        public long Id{ get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
