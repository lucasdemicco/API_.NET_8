using ProductsConsumer.Consumer;
using Services.Interface.External.Interface;
using Services.Service.External;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();

var host = builder.Build();
host.Run();
