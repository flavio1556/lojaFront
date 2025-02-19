using Lojaback.Domain.Interfaces.Entities;
using Lojaback.Domain.Interfaces.Repository;
using Lojaback.Domain.Interfaces.SaveHandlers;
using Lojaback.Domain.Interfaces.Services;
using Lojaback.Domain.Model;
using LojaBack.Application.Interfaces.Mapper;
using LojaBack.Application.SaveHandlers;
using LojaBack.Application.Services;
using LojaBack.Infra.Data.RepositoryService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBack.Infra.Ioc.DependencyInjectionExtension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddMapper();
            services.AddRepository();
            services.AddService();
            services.AddSaveHandler();
            // Outros serviços a serem injetados...
            return services;
        }
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();
        }
        public static void AddRepository(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IServiceBase<IModel>, ServiceBase<IModel>>();
            services.AddScoped<IServiceBase<Product>, ProductService>()
                .AddScoped<ProductService>();
        }
        public static void AddUseCase(this IServiceCollection services) 
        {

        }
        public static void AddSaveHandler(this IServiceCollection services)
        {
            services.AddTransient(typeof(ISaveHandler<>), typeof(SaveHandler<>));

            services.AddScoped<ISaveHandler<Product>, ProductSaveHandler>()
                .AddScoped<ProductSaveHandler>();
        }
    }
}
