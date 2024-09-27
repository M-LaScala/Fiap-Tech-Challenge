namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Message.Broker.Settings
{
    public class RabbitApplicationQueueSettings
    {
        public RabbitQueueSettings ContatoCriadoV1 { get; set; }

        public RabbitQueueSettings ContatoAtualizadoV1 { get; set; }

        public RabbitQueueSettings ContatoDeletadoV1 { get; set; }
    }
}
