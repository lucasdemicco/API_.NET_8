using Domain.Dto;
using Domain.Records;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services.Interface.External.Interface;
using System.Text;

namespace Services.Service.External
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly ILogger<RabbitMqService> _logger;
        private readonly RabbitMqInfos _rabbitMqInfos;

        public RabbitMqService(ILogger<RabbitMqService> logger, RabbitMqInfos rabbitMqInfos)
        {
            _logger = logger;
            _rabbitMqInfos = rabbitMqInfos;
        }

        public Task SendMessageAsync(ProductDto product)
        {
            string message = JsonConvert.SerializeObject(product);
            _logger.LogInformation($"Requuest message: {message}");

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(_rabbitMqInfos.Exchange, ExchangeType.Fanout);

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: _rabbitMqInfos.Exchange, routingKey: _rabbitMqInfos.RoutingKey, basicProperties: null, body);

            _logger.LogInformation("Mensagem publicada no tópico com sucesso!");
            return Task.CompletedTask;  
        }

        public Task ConsumeMessageAsync(string queueName, string routingKey, string exchangeName)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare(queueName, ExchangeType.Fanout);
            channel.QueueDeclare(queueName);
            channel.QueueBind(queueName, exchangeName, routingKey);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) => 
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation($"Receive message: {message}");

                //Add Deserialize string message to C# object and handle message here
            };

            channel.BasicConsume(queueName, true, consumer);
            return Task.CompletedTask;  
        }
    }
}
