using Domain.Records;
using Services.Interface.External.Interface;

namespace ProductsConsumer.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRabbitMqService _rabbitMqService;
        private readonly RabbitMqInfos _rabbitMqInfos;

        public Worker(ILogger<Worker> logger, IRabbitMqService rabbitMqService, RabbitMqInfos rabbitMqInfos)
        {
            _logger = logger;
            _rabbitMqService = rabbitMqService;
            _rabbitMqInfos = rabbitMqInfos;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await _rabbitMqService.ConsumeMessageAsync(_rabbitMqInfos.Queue, _rabbitMqInfos.RoutingKey, _rabbitMqInfos.Exchange);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
