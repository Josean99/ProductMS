using Infrastructure.RabbitMq.Messages;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq.Publish
{
    public interface IMessagePublisher
    {
        Task PublishDomainMessage(object data, Metadata metadata, string? routingKey = null, CancellationToken cancellationToken = default);
        Task PublishIntegrationMessage(object data, Metadata metadata, string? routingKey = null, CancellationToken cancellationToken = default);
        Task PublishManyDomainMessage(List<object> data,Metadata metadata, string? routingKey = null, CancellationToken cancellationToken = default);
        Task PublishManyIntegrationMessage(List<object> data, Metadata metadata, string? routingKey = null, CancellationToken cancellationToken = default);
    }

    public class MessagePublisher : IMessagePublisher
    {
        private readonly ConnectionFactory _connectionFactory;

        private readonly Newtonsoft.Json.JsonSerializer _jsonSerializer;
        private static readonly JsonSerializerSettings DefaultSerializerSettings =
        new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        private readonly string DomainExchange;
        private readonly string IntegrationExchange;
        private readonly string ResponseIntegrationExchange;

        public MessagePublisher(IConfiguration configuration)
        {
            _jsonSerializer = Newtonsoft.Json.JsonSerializer.Create(DefaultSerializerSettings);
            RabbitMQSettings rabbitMQSettings = configuration.GetSection("RabbitMq").Get<RabbitMQSettings>();
            _connectionFactory = new ConnectionFactory()
            {
                HostName = rabbitMQSettings.Credentials.Hostname,
                Password = rabbitMQSettings.Credentials.Password,
                UserName = rabbitMQSettings.Credentials.Username,
            };
            DomainExchange = rabbitMQSettings.DomainExchange;
            IntegrationExchange = rabbitMQSettings.IntegrationExchange;
        }

        #region DomainMessage
        public Task PublishDomainMessage(object data, Metadata? metadata = null, string? routingKey = null, CancellationToken cancellationToken = default)
        {
            using IConnection connection = _connectionFactory.CreateConnection();
            using IModel model = connection.CreateModel();

            var properties = model.CreateBasicProperties();
            properties.Persistent = true;
            properties.Type = data.GetType().FullName;

            if (metadata is null)
            {
                metadata = new Metadata(Guid.NewGuid().ToString(), DateTime.UtcNow);
            }

            DomainMessage<object> message = new DomainMessage<object>(data, metadata);

            model.BasicPublish(exchange: DomainExchange,
                routingKey: routingKey ?? "",
                basicProperties: properties,
                body: SerializeObjectToByteArray(message));

            return Task.CompletedTask;
        }

        //public Task PublishRPCDomainMessage<T>(object data, Metadata? metadata = null, string ? routingKey = null, CancellationToken cancellationToken = default) where T : class
        //{
        //    using IConnection connection = _connectionFactory.CreateConnection();
        //    using IModel model = connection.CreateModel();

        //    var properties = model.CreateBasicProperties();
        //    properties.Persistent = true;
        //    properties.Type = data.GetType().FullName;
        //    var correlationId = Guid.NewGuid().ToString();
        //    properties.CorrelationId = correlationId;
        //    properties.ReplyTo = ResponseIntegrationExchange;

        //    callbackMapper.TryAdd(correlationId, tcs);

        //    channel.BasicPublish(exchange: string.Empty,
        //                         routingKey: QUEUE_NAME,
        //                         basicProperties: props,
        //                         body: messageBytes);

        //    cancellationToken.Register(() => callbackMapper.TryRemove(correlationId, out _));
        //    return tcs.Task;
        //}

        public Task PublishManyDomainMessage(List<object> data,Metadata metadata, string? routingKey = null, CancellationToken cancellationToken = default)
        {
            using IConnection connection = _connectionFactory.CreateConnection();
            using IModel model = connection.CreateModel();

            var properties = model.CreateBasicProperties();
            properties.Persistent = true;

            if (metadata is null)
            {
                metadata = new Metadata(Guid.NewGuid().ToString(), DateTime.UtcNow);
            }

            foreach (object d in data)
            {
                properties.Type = d.GetType().FullName;
                DomainMessage<object> message = new DomainMessage<object>(data, metadata);
                model.BasicPublish(exchange: DomainExchange,
                    routingKey: routingKey ?? "",
                    basicProperties: properties,
                    body: SerializeObjectToByteArray(message));
            }

            return Task.CompletedTask;
        }

        #endregion

        #region IntegrationMessage
        public Task PublishIntegrationMessage(object data, Metadata metadata, string? routingKey = null, CancellationToken cancellationToken = default)
        {
            using IConnection connection = _connectionFactory.CreateConnection();
            using IModel model = connection.CreateModel();

            var properties = model.CreateBasicProperties();
            properties.Persistent = true;
            properties.Type = data.GetType().FullName;

            if (metadata is null)
            {
                metadata = new Metadata(Guid.NewGuid().ToString(), DateTime.UtcNow);
            }

            IntegrationMessage<object> message = new IntegrationMessage<object>(data, metadata);

            model.BasicPublish(exchange: IntegrationExchange,
                routingKey: routingKey ?? "",
                basicProperties: properties,
                body: SerializeObjectToByteArray(message));

            return Task.CompletedTask;
        }

        public Task PublishManyIntegrationMessage(List<object> data, Metadata metadata, string? routingKey = null, CancellationToken cancellationToken = default)
        {
            using IConnection connection = _connectionFactory.CreateConnection();
            using IModel model = connection.CreateModel();

            var properties = model.CreateBasicProperties();
            properties.Persistent = true;

            if (metadata is null)
            {
                metadata = new Metadata(Guid.NewGuid().ToString(), DateTime.UtcNow);
            }

            foreach (object d in data)
            {
                properties.Type = d.GetType().FullName;
                IntegrationMessage<object> message = new IntegrationMessage<object>(data, metadata);
                model.BasicPublish(exchange: IntegrationExchange,
                    routingKey: routingKey ?? "",
                    basicProperties: properties,
                    body: SerializeObjectToByteArray(message));
            }

            return Task.CompletedTask;
        }

        #endregion

        #region private
        private byte[] SerializeObjectToByteArray<T>(T obj)
        {
            Encoding Encoding = new UTF8Encoding(false);
            int DefaultBufferSize = 1024;

            using var memoryStream = new MemoryStream(DefaultBufferSize);
            using (var streamWriter = new StreamWriter(memoryStream, Encoding, DefaultBufferSize, true))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                jsonWriter.Formatting = _jsonSerializer.Formatting;
                _jsonSerializer.Serialize(jsonWriter, obj, obj!.GetType());
            }

            return memoryStream.ToArray();
        }
        #endregion

    }
}
