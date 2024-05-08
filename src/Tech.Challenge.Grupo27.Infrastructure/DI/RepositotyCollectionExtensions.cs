using Microsoft.Extensions.DependencyInjection;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Models.RegioesDddAggregate;
using Tech.Challenge.Grupo27.Domain.Shared;
using Tech.Challenge.Grupo27.Infrastructure.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Infrastructure.Domain.Models.RegioesDddAggregate;
using Tech.Challenge.Grupo27.Infrastructure.EntityFrameworkCore;

namespace Tech.Challenge.Grupo27.Infrastructure.DI
{
    public static class RepositotyCollectionExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IRegiaoDddRepository, RegiaoDddRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
