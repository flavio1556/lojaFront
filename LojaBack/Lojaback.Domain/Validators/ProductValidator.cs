using FluentValidation;
using Lojaback.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojaback.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .WithMessage("Nome é Obrigatório.");

            RuleFor(x => x.Price)
              .NotEqual(default(decimal)).WithMessage("O preço não pode ser 0.")
              .GreaterThanOrEqualTo(0).WithMessage("O preço não pode ser menor que 0.")
              .NotEmpty()
              .WithMessage("Preço é required.");
        }
    }
}
