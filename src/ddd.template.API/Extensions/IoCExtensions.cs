using ddd.template.Application.Service.v1;
using ddd.template.Domain.Interfaces.Repository;
using ddd.template.Domain.Interfaces.Service;
using ddd.template.Domain.Service;
using ddd.template.Infra.Context.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ddd.template.API.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddIoC(this IServiceCollection services) =>
          services
              .AddInfra()
              .AddAppService()
              .AddServices();

        private static IServiceCollection AddInfra(this IServiceCollection services) =>
         services
             .AddScoped<IExampleRepository, ExampleRepository>();
        private static IServiceCollection AddAppService(this IServiceCollection services) =>
            services.AddScoped<ExampleAppService>();
        private static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddScoped<IExampleService, ExampleService>();
    }
}
