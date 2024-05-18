using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tech.Challenge.Grupo27.Infrastructure.EntityFrameworkCore;

namespace Tech.Challenge.Grupo27.Infrastructure.DI
{
    public static class DatabaseServiceCollectionExtensions
    {
        public static void AddSqlServerProvider(this IServiceCollection services, DbOptions dbOptions)
        {

            services.AddDbContext<TechChallengeGrupo27Context>(options =>
            {
                options.UseSqlServer(dbOptions.ConnectionString);
            }, ServiceLifetime.Scoped);

            var dbContextBuilder = new DbContextOptionsBuilder<TechChallengeGrupo27Context>().UseSqlServer(dbOptions.ConnectionString);
            services.AddSingleton(dbContextBuilder.Options);
        }
    }
}
