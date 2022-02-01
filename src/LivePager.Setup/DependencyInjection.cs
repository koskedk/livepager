using System.Collections.Generic;
using System.Reflection;
using LivePager.Setup.Application.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LivePager.Setup
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> mediatrAssemblies = null, bool initProcess = true)
        {
            if (null != mediatrAssemblies)
            {
                mediatrAssemblies.Add(typeof(ConfigureLiveRowIdHandler).Assembly);
                services.AddMediatR(mediatrAssemblies.ToArray());
            }
            else
            {
                services.AddMediatR(typeof(ConfigureLiveRowIdHandler).Assembly);
            }

            return services;
        }
    }
}
