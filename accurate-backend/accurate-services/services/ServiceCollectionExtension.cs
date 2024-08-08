using accurate_data_access.interfaces;
using accurate_repositry.repository;
using Microsoft.Extensions.DependencyInjection;

namespace accurate_services.services
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<ProductService>();
            services.AddScoped<CategoryService>();
        }
    }
}
