using Infrastructure.RabbitMq.Messages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq.Publish
{
    public class MessageConsumer
    {
        private readonly ConnectionFactory _connectionFactory;

        private readonly Newtonsoft.Json.JsonSerializer _jsonSerializer;
        private static readonly JsonSerializerSettings DefaultSerializerSettings =
        new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public MessageConsumer(IConfiguration configuration)
        {
            RabbitMQSettings rabbitMQSettings = configuration.GetSection("RabbitMq").Get<RabbitMQSettings>();
            _connectionFactory = new ConnectionFactory()
            {
                HostName = rabbitMQSettings.Hostname,
                Password = rabbitMQSettings.Password,
                UserName = rabbitMQSettings.Username,
            };
        }

        public Task ConsumeMessages<T>(DomainMessage<T> message, string? routingKey = null, CancellationToken cancellationToken = default) where T : class
        {
            using IConnection connection = _connectionFactory.CreateConnection();
            using IModel model = connection.CreateModel();

            var consumer = new EventingBasicConsumer(model);
            consumer.Received += (model, ea) =>
            {
                //
                if (!callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    return;
                var body = ea.Body.ToArray();
                var response = Encoding.UTF8.GetString(body);
                tcs.TrySetResult(response);
            };

            model.BasicConsume(consumer: consumer,
                                 queue: replyQueueName,
                                 autoAck: true);

            return Task.CompletedTask;
        }
    }
}
