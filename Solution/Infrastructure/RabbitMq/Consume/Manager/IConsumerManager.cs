namespace Infrastructure.RabbitMq.Consume;

public interface IConsumerManager<TMessage>
{
    void RestartExecution();
    void StopExecution();
    CancellationToken GetCancellationToken();
}