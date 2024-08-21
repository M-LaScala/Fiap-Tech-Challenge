using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Message.Broker.Settings
{
    public class RabbitServiceApplicationSettings
    {
        public string ConnectionString { get; set; }

        public int ConcurrencyLimit { get; set; }

        public int OperationTimeout { get; set; }       

        public RabbitApplicationQueueSettings Queues { get; set; }
    }
}
