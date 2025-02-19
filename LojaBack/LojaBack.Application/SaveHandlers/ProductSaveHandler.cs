using FluentValidation;
using Lojaback.Domain.Interfaces.Repository;

namespace LojaBack.Application.SaveHandlers
{
    public class ProductSaveHandler : SaveHandler<Lojaback.Domain.Model.Product>
    {
        private readonly IRepository<Lojaback.Domain.Model.Product> _repository;
        IValidator<Lojaback.Domain.Model.Product>? _validator;
        public ProductSaveHandler(
            IRepository<Lojaback.Domain.Model.Product> repository,
            IValidator<Lojaback.Domain.Model.Product>? validator = null
        ) : base(repository, validator)
        {
            this._validator = validator;
            this._repository = repository;
        }
    }
}
