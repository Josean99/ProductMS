using Infrastructure.RabbitMq.Consume;
using Infrastructure.RabbitMq.Consume.Host;
using Infrastructure.RabbitMq.Consume.Manager;
using Infrastructure.RabbitMq.Messages;
using Infrastructure.RabbitMq.Publish;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.RabbitMq;

public static class CommunicationDependencyInjection
{
    public static void AddConsumer<TMessage>(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IConsumerManager<TMessage>, ConsumerManager<TMessage>>();
        serviceCollection.AddSingleton<IHostedService, ConsumerHostedService<TMessage>>();
    }

    public static void AddPublisher<TMessage>(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddBusMessagePublisher();
    }

    private static void AddBusMessagePublisher(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IMessagePublisher, MessagePublisher>();
    }
}