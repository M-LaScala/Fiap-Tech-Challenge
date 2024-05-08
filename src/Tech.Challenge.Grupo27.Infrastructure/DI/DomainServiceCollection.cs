using Microsoft.Extensions.DependencyInjection;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Challenge.Grupo27.Infrastructure.DI
{
    public static class DomainServiceCollection
    {
        public static void AddDomainService(this IServiceCollection services)
        {
            services.AddScoped<INotificacaoContext, NotificacaoContext>();
            services.AddScoped<IContatoService, ContatoService>();
        }
    }
}
