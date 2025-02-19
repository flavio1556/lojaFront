using Lojaback.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojaback.Domain.Filter
{
    public class Filter<T> where T : class, IModel
    {
        public Dictionary<string, object> Filters { get; set; } = new Dictionary<string, object>();

        // Adiciona filtros ao dicionário
        public void AddFilter(string propertyName, object value)
        {
            Filters[propertyName] = value;
        }
    }

}
