﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Htn.Arq.Base.WebApi.HealthChecks
{
    public class MyCustomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context
            , CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            // ...

            if (isHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("A healthy result."));
            }

            return Task.FromResult(
                new HealthCheckResult(
                    context.Registration.FailureStatus, "An unhealthy result."));
        }
    }
}
