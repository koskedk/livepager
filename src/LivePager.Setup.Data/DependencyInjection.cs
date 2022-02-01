using LivePager.Setup.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace LivePager.Setup.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, bool initDb = true)
        {
            services
                .AddScoped<IDbConnector, DbConnector>();

            return services;
        }
    }
}
