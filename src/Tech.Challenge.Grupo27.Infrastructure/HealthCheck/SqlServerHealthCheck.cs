using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Tech.Challenge.Grupo27.Infrastructure.HealthCheck
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        private readonly string _connectionString;
        private readonly string _sql;
        private readonly Action<SqlConnection> _beforeOpenConnectionConfigurer;

        public SqlServerHealthCheck
        (
            string connectionString,
            string sql,
            Action<SqlConnection> beforeOpenConnectionConfigurer = null)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _sql = sql ?? throw new ArgumentNullException(nameof(sql));
            _beforeOpenConnectionConfigurer = beforeOpenConnectionConfigurer;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using ( var connection = new SqlConnection(_connectionString)) 
                {
                    _beforeOpenConnectionConfigurer?.Invoke(connection);
                    await connection.OpenAsync(cancellationToken);

                    using( var command = connection.CreateCommand()) 
                    {
                        command.CommandText = _sql;
                        await command.ExecuteNonQueryAsync(cancellationToken);
                    }

                    return HealthCheckResult.Healthy();
                }
            }
            catch (Exception ex)
            {

                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}
