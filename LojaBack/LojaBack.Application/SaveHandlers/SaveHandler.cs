using Lojaback.Domain.Interfaces.Entities;
using Lojaback.Domain.Interfaces.SaveHandlers;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;
using Lojaback.Domain.Interfaces.Repository;


namespace LojaBack.Application.SaveHandlers
{
     public class SaveHandler<T> : ISaveHandler<T> where T :class, IModel
    {
        private readonly IValidator<T>? _validator;
        private readonly IRepository<T> _repository;

        public SaveHandler(IRepository<T> repository, IValidator<T>? validator = null)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validator = validator;
        }
        public async Task ValidateAsync(T model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "A entidade não pode ser nula.");

            if (_validator != null)
            {
                var validationResult = await _validator.ValidateAsync(model);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                    throw new ValidationException($"Validação falhou: {errors}");
                }
            }
        }
    }
}
