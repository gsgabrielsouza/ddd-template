using ddd.template.Domain.Interfaces.UnitOfWork;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ddd.template.API.HealthCheck
{
    public class HealthCheckAPI : IHealthCheck
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<HealthCheckAPI> log;

        public HealthCheckAPI(IUnitOfWork unitOfWork, ILogger<HealthCheckAPI> log = null)
        {
            this.unitOfWork = unitOfWork;
            this.log = log;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                if (await unitOfWork.HealthCheck())
                    return await Task.FromResult(HealthCheckResult.Healthy());
                else
                {
                    log.LogError($"Health Check BancoDados - Unhealthy");
                    return await Task.FromResult(HealthCheckResult.Unhealthy());
                }

            }
            catch (Exception ex)
            {
                log.LogError($"Health Check BancoDados - Unhealthy", ex);
                return await Task.FromResult(HealthCheckResult.Unhealthy());
            }
        }
    }
}
