using Infrastructure.RabbitMq.Messages;

namespace Infrastructure.RabbitMq.Consume.Handler;

public interface IMessageHandler
{
}

public interface IMessageHandler<in TMessage> : IMessageHandler
{
    Task Handle(TMessage message, CancellationToken cancelToken = default);
}

public interface IIntegrationMessageHandler : IMessageHandler
{
}

public interface IIntegrationMessageHandler<TMessage>
    : IMessageHandler<IntegrationMessage<TMessage>>, IIntegrationMessageHandler where TMessage : class
{
}

public interface IDomainMessageHandler : IMessageHandler
{
}

public interface IDomainMessageHandler<TMessage>
    : IMessageHandler<DomainMessage<TMessage>>, IDomainMessageHandler where TMessage : class
{
}