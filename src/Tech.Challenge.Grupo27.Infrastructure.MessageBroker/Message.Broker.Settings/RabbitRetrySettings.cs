namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Message.Broker.Settings
{
    public class RabbitRetrySettings
    {
        public int RetryLimit { get; set; }

        public int MinimumInterval { get; set; }

        public int MaximumInteval { get; set; }

        public int IntervalDelta { get; set; }
    }
}
