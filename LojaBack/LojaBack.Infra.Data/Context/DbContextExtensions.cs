using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LojaBack.Infra.Data.Context
{
     public static class DbContextExtensions
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
          var connection = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connection)) 
            {
                services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppInMemoryDb"));
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(connection));
                Console.WriteLine("🔗 Usando banco de dados PostgreSQL.");
            }

            return services;
        }
    }
}
