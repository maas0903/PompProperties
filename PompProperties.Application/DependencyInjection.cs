using Microsoft.Extensions.DependencyInjection;

namespace PompProperties.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<IRepository, Repository>();
            return services;
        }
    }
}
