using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace shop.API.HealthChecks
{
    public class CustomHealthChecks : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            //API Geliştiricisi, standart halthcheck dışında denetlemek istediği her alanı burada denetler. Ardından "Sağlıklı" olup olmadığı bilgisini döndürür:
            return await Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
