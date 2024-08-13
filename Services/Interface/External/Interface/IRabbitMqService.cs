using Domain.Dto;

namespace Services.Interface.External.Interface
{
    public interface IRabbitMqService
    {
        Task SendMessageAsync(ProductDto product);
        Task ConsumeMessageAsync(string queueName, string routingKey, string exchangeName);
    }
}
