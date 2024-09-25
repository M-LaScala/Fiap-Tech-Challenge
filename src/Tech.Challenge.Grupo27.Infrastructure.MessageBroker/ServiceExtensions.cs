using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tech.Challenge.Grupo27.Domain.Commands;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Consumers;
using Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Message.Broker.Settings;
using Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Producers;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMessageBrokerServiceConsumer(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddRabbitmqServerConsumer(configuration);
            return services;
        }

        public static IServiceCollection AddMessageBrokerServiceProducer(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = GetRabbitmqSettings(configuration);
            services.AddScoped<IContatoCriadoProducer, ContatoCriadoProducer>();
            services.AddRabbitmqServiceProducer(settings);
            
            return services;
        }

        private static RabbitmqServiceSettings GetRabbitmqSettings(IConfiguration configuration)
        {
            return configuration.GetSection("RabbitmqServiceSettings").Get<RabbitmqServiceSettings>();
        }

        public static void AddRabbitmqServiceProducer(this IServiceCollection services, RabbitmqServiceSettings serviceSettings)
        {            
            services.AddMassTransit<IBusControl>(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseConcurrencyLimit(serviceSettings.ContatoEvent.ConcurrencyLimit);
                    cfg.Host(serviceSettings.ContatoEvent.ConnectionString, h =>
                    {
                        h.RequestedConnectionTimeout(TimeSpan.FromSeconds(serviceSettings.ContatoEvent.OperationTimeout));
                        h.Username(serviceSettings.User);
                        h.Password(serviceSettings.Password);
                    });

                    EndpointConvention.Map<ContatoCriadoCommand>
                    (serviceSettings.ContatoEvent.Queues.ContatoCriadoV1.GetUrl(serviceSettings.ContatoEvent.ConnectionString));
                   
                    cfg.Message<ContatoCriadoCommand>(message =>
                    {
                        message.SetEntityName(serviceSettings.ContatoEvent.Queues.ContatoCriadoV1.Name);
                    });
                });
                
            });
           
        }

        public static void AddRabbitmqServerConsumer(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitmqSetting = GetRabbitmqSettings(configuration);            
            services.AddMassTransit<IBusControl>(x =>
            {
                x.AddConsumer<ContatoCriadaConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseConcurrencyLimit(rabbitmqSetting.ContatoEvent.ConcurrencyLimit);
                    cfg.Host(rabbitmqSetting.ContatoEvent.ConnectionString, h =>
                    {
                        h.RequestedConnectionTimeout(TimeSpan.FromSeconds(rabbitmqSetting.ContatoEvent.OperationTimeout));
                        h.Username(rabbitmqSetting.User);
                        h.Password(rabbitmqSetting.Password);
                    });

                    cfg.ReceiveEndpoint(rabbitmqSetting.ContatoEvent.Queues.ContatoCriadoV1.Name, e =>
                    {
                        e.PrefetchCount = rabbitmqSetting.ContatoEvent.Queues.ContatoCriadoV1.PrefetchCount;
                        e.ConfigureConsumer<ContatoCriadaConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(rabbitmqSetting.Retry.MinimumInterval, rabbitmqSetting.Retry.MaximumInteval));
                        EndpointConvention.Map<ContatoCriadoCommand>(e.InputAddress);
                    });
                });
            });                      

        }
    }
}
