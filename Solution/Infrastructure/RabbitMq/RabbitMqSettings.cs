using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq
{
    public class RabbitMQSettings
    {
        public RabbitMQCredentials Credentials { get; init; } = null!;
        public string DomainExchange { get; private set; } = null!;
        public string IntegrationExchange { get; private set; } = null!;
        public string ResponseIntegrationExchange { get; private set; } = null!;
    }

    public class RabbitMQCredentials
    {
        public string Hostname { get; private set; } = null!;
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;
    }

}
