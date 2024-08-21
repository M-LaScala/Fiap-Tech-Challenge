using System;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Message.Broker.Settings
{
    public class RabbitQueueSettings
    {
        public string Name { get; set; }

        public ushort PrefetchCount { get; set; }

        public Uri GetUrl(string host)
        {
            return new Uri($"{host}/{Name}");
        }
    }
}
