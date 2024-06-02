using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.RabbitMq.Messages
{

    public class DomainMessage<T> : Message<T> where T : class
    {
        public DomainMessage(T data, Metadata metadata) :base(data, metadata){}
    }

    public class IntegrationMessage<T> : Message<T> where T : class
    {
        public IntegrationMessage(T data, Metadata metadata) : base(data, metadata){}
    }

    public class Message<T> where T : class
    {
        public T Data { get; set; }
        public Metadata Metadata { get; set; }

        public Message(T data, Metadata metadata)
        {
            Data = data;
            Metadata = metadata;
        }
    }

    public record Metadata
    {
        public string CorrelationId { get; }
        public DateTime CreatedUtc { get; }

        public Metadata(string correlationId, DateTime createdUtc)
        {
            CorrelationId = correlationId;
            CreatedUtc = createdUtc;
        }
    }
}
