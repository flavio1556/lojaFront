using Lojaback.Domain.Interfaces.Repository;
using Lojaback.Domain.Interfaces.SaveHandlers;
using Lojaback.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBack.Application.Services
{
    public class ProductService : ServiceBase<Product>
    {
        private readonly IRepository<Product> _repository;
        private readonly ISaveHandler<Product> _saveHandler;
        public ProductService(IRepository<Product> repository, ISaveHandler<Product> saveHandler) : base(repository, saveHandler)
        {
            this._saveHandler = saveHandler;
            this._repository = repository;
        }
    }
}
