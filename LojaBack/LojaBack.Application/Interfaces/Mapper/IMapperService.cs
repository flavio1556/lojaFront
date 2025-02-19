using Lojaback.Domain.Interfaces.Entities;
using LojaBack.Application.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBack.Application.Interfaces.Mapper
{
     public interface IMapperService
    {
        TDestination MapToModel<TSource, TDestination>(TSource source)
                where TSource : class, IDto
                where TDestination : class, IModel;

        IEnumerable<TDestination> MapListToModel<TSource, TDestination>(IEnumerable<TSource> source)
            where TSource : class, IDto
            where TDestination : class, IModel;

        TDestination MapToDto<TSource, TDestination>(TSource source)
            where TSource : class, IModel
            where TDestination : class, IDto;

        IEnumerable<TDestination> MapListToDto<TSource, TDestination>(IEnumerable<TSource> source)
            where TSource : class, IModel
            where TDestination : class, IDto;
    }
}
