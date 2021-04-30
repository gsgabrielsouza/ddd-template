using ddd.template.Domain.Interfaces.UnitOfWork;
using ddd.template.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ddd.template.API.Extensions
{
    public static class DbExtension
    {
        public static IServiceCollection AddEF(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<ServiceDbContext>(x => x.UseInMemoryDatabase("LocalTest"));
            service.AddScoped<IUnitOfWork, ServiceDbContext>(provider => provider.GetService<ServiceDbContext>());
            return service;
        }

        public static IServiceCollection Migration(this IServiceCollection services)
        {
            using var db = services.BuildServiceProvider().GetService<ServiceDbContext>();
            db.Database.Migrate();
            return services;
        }
    }
}