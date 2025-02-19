using Lojaback.Domain.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBack.Application.UseCases
{
    public abstract class UseCaseBase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public abstract Task<TResponse> HandleAsync(TRequest request);

        public async Task<TResponse> ExecuteAsync(TRequest request)
        {
            return await HandleAsync(request);
        }
    }
}
