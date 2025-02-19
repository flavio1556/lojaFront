using LojaBack.Application.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBack.Application.Dto
{
    public class ProductDto: IDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
