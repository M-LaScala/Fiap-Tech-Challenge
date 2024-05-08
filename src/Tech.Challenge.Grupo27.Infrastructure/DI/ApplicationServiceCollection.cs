using Microsoft.Extensions.DependencyInjection;
using Tech.Challenge.Grupo27.Application.Contatos.InserirContato.Handler_;

namespace Tech.Challenge.Grupo27.Infrastructure.DI
{
    public static class ApplicationServiceCollection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InserirContatoHandler).Assembly));
        }
    }
}
