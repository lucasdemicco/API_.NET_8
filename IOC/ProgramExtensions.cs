using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interface;
using Services.Service;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.Interface;
using Infrastructure.Repository.Service;

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
            return services;
        }

        private static IServiceCollection ServicesInjections(this IServiceCollection services) 
        {
            //CONFIGURING SERVICES
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            //CONFIGURING REPOSITORIES
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
