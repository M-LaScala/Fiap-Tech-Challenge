using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tech.Challenge.Grupo27.Infrastructure.EntityFrameworkCore
{
    public class DesingTimeDbContext : IDesignTimeDbContextFactory<TechChallengeGrupo27Context>
    {
        public TechChallengeGrupo27Context CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var schema = "techchanllenge";

            var builder = new DbContextOptionsBuilder<TechChallengeGrupo27Context>();
            builder.UseSqlServer(connectionString);

            return new TechChallengeGrupo27Context(builder.Options, new DbOptions(connectionString, schema));

        }
    }
}
