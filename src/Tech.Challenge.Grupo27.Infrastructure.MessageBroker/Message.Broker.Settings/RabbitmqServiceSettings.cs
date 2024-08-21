using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Message.Broker.Settings
{
    public class RabbitmqServiceSettings
    {        
        public RabbitRetrySettings Retry { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public RabbitServiceApplicationSettings ContatoEvent { get; set; }
    }
}
