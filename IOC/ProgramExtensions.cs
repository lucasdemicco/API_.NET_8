using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interface;
using Services.Service;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.Interface;
using Infrastructure.Repository.Service;
using Infrastructure.UOW.Interface;
using Infrastructure.UOW.Service;
using Services.Interface.External.Interface;
using Services.Service.External;
using Domain.Records;

namespace IOC
{
    public static class ProgramExtensions
    {
        public static IServiceCollection BuildProgramExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));
            ArgumentNullException.ThrowIfNull(services, nameof(configuration));

            BindConfigurations(services, configuration);
            ServicesInjections(services);
            ConfigureDataSource(services, configuration);

            return services;
        }

        private static IServiceCollection ConfigureDataSource(this IServiceCollection services, IConfiguration configuration)
        {
            //DATASOURCE 
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        private static IServiceCollection BindConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            string exchange = configuration.GetRequiredSection("RabbitMq:Exchange").Value ?? throw new InvalidCastException();
            string queue = configuration.GetRequiredSection("RabbitMq:Queue").Value ?? throw new InvalidCastException();
            string routingKey = configuration.GetRequiredSection("RabbitMq:RoutingKey").Value ?? throw new InvalidCastException();
            RabbitMqInfos rabbitMqInfos = new(exchange, queue, routingKey);
            services.AddSingleton(rabbitMqInfos);

            return services;
        }

        private static IServiceCollection ServicesInjections(this IServiceCollection services) 
        {
            //CONFIGURING SERVICES
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRabbitMqService, RabbitMqService>();

            //CONFIGURING REPOSITORIES
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
