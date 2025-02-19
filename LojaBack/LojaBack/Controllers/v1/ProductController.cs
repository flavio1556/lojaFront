using Lojaback.Domain.Interfaces.Services;
using Lojaback.Domain.Model;
using LojaBack.Application.Dto;
using LojaBack.Application.Interfaces.Mapper;
using LojaBack.WebUI.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace LojaBack.WebUI.Controllers.v1
{
    public class ProductController : BaseCrudController<ProductDto, Product>
    {
        private readonly IServiceBase<Product> _service;
        private readonly IMapperService _mapperService;

        public ProductController(IMapperService mapperService, IServiceBase<Product> serviceBase): base(serviceBase, mapperService)
        {
            _mapperService = mapperService;
        }

    }
}
