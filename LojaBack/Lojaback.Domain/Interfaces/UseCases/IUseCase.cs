using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojaback.Domain.Interfaces.UseCases
{
    public interface IUseCase<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
