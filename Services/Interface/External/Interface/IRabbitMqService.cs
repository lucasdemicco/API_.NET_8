namespace Services.Interface.External.Interface
{
    public interface IRabbitMqService
    {
        Task SendMessageAsync(string message);
        Task ConsumeMessageAsync(string queueName, string routingKey, string exchangeName);
    }
}
