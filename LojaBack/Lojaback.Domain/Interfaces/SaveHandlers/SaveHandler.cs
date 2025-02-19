using Lojaback.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojaback.Domain.Interfaces.SaveHandlers
{
    public interface ISaveHandler<T> where T : IModel
    {
        Task ValidateAsync(T model);
    }
}
