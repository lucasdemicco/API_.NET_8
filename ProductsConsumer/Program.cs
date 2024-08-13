using Domain.Records;
using ProductsConsumer.Consumer;
using Services.Interface.External.Interface;
using Services.Service.External;
var builder = Host.CreateApplicationBuilder(args);

string exchange = builder.Configuration.GetRequiredSection("RabbitMq:Exchange").Value ?? throw new InvalidCastException();
string queue = builder.Configuration.GetRequiredSection("RabbitMq:Queue").Value ?? throw new InvalidCastException();
string routingKey = builder.Configuration.GetRequiredSection("RabbitMq:RoutingKey").Value ?? throw new InvalidCastException();
RabbitMqInfos rabbitMqInfos = new(exchange, queue, routingKey);
builder.Services.AddSingleton(rabbitMqInfos);

builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();

var host = builder.Build();
host.Run();
