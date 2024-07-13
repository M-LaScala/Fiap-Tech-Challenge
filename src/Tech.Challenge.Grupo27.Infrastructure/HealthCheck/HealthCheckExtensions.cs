using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Tech.Challenge.Grupo27.Infrastructure.HealthCheck
{
    public static class HealthCheckExtensions 
    {

        public static void UseHealthCheckCustom(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                Predicate = ((HealthCheckRegistration _) => true),
                ResultStatusCodes = { [HealthStatus.Degraded] = 200},                
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
        public static IHealthChecksBuilder AddSqlServer
        (
            this IHealthChecksBuilder healthChecksBuilder,
            string connectionString,
            string healthcheckQuery = default,
            string name = default,
            HealthStatus? healthStatus = default,
            IEnumerable<string> tags = default,
            TimeSpan? timeout = default,
            Action<SqlConnection> beforeOpenConnectionConfigurer = default)
        {
            return healthChecksBuilder.AddSqlServer(_ => connectionString, healthcheckQuery, name, healthStatus, tags, timeout, beforeOpenConnectionConfigurer);
        }

        public static IHealthChecksBuilder AddSqlServer
       (
           this IHealthChecksBuilder healthChecksBuilder,
           Func<IServiceProvider, string> ConnectStringStringFactory,
           string healthcheckQuery = default,
           string name = default,
           HealthStatus? healthStatus = default,
           IEnumerable<string> tags = default,
           TimeSpan? timeout = default,
           Action<SqlConnection> beforeOpenConnectionConfigurer = default)
        {
            if (ConnectStringStringFactory == null)
            {
                throw new ArgumentNullException(nameof(ConnectStringStringFactory));
            }

            return healthChecksBuilder.Add(new HealthCheckRegistration
            (
                name ?? "sqlserver",
                sp => new SqlServerHealthCheck(ConnectStringStringFactory(sp),
                healthcheckQuery ?? "Select 1;",
                beforeOpenConnectionConfigurer),
                healthStatus,
                tags,
                timeout));
        }
    }
}
