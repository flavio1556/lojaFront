using LojaBack.Application.Interfaces.Dto;
using Lojaback.Domain.Interfaces.Entities;
using LojaBack.Application.Interfaces.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LojaBack.Application.Services
{
    public class MapperService : IMapperService
    {
        public virtual TDestination MapToModel<TSource, TDestination>(TSource source)
        where TSource : class, IDto
        where TDestination : class, IModel
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return MapProperties<TSource, TDestination>(source);
        }

        public virtual IEnumerable<TDestination> MapListToModel<TSource, TDestination>(IEnumerable<TSource> source)
            where TSource : class, IDto
            where TDestination : class, IModel
        {
            return source.Select(MapToModel<TSource, TDestination>);
        }

        // De Model para DTO
        public virtual TDestination MapToDto<TSource, TDestination>(TSource source)
            where TSource : class, IModel
            where TDestination : class, IDto
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return MapProperties<TSource, TDestination>(source);
        }

        public virtual IEnumerable<TDestination> MapListToDto<TSource, TDestination>(IEnumerable<TSource> source)
            where TSource : class, IModel
            where TDestination : class, IDto
        {
            return source.Select(MapToDto<TSource, TDestination>);
        }

        protected virtual TDestination MapProperties<TSource, TDestination>(TSource source)
             where TSource : class
             where TDestination : class
        {
            var destination = Activator.CreateInstance<TDestination>();

            var sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var sourceProp in sourceProperties)
            {
                var targetProp = destinationProperties.FirstOrDefault(p => p.Name == sourceProp.Name
                    && p.PropertyType == sourceProp.PropertyType);

                if (targetProp != null && targetProp.CanWrite)
                {
                    var value = sourceProp.GetValue(source);
                    targetProp.SetValue(destination, value);
                }
            }

            return destination;
        }


    }
}
