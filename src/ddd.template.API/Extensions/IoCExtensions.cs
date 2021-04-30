using Microsoft.Extensions.DependencyInjection;
using System;

namespace ddd.template.API.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddIoC(this IServiceCollection services) =>
          services
              .AddInfra()
              .AddAppService()
              .AddServices();

        private static IServiceCollection AddInfra(this IServiceCollection services) => throw new NotImplementedException();
        private static IServiceCollection AddAppService(this IServiceCollection services) => throw new NotImplementedException();
        private static IServiceCollection AddServices(this IServiceCollection services) => throw new NotImplementedException();
    }
}
