using MarsRover.Business.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.Business
{
    public static class BusinessInjections
    {
        public static ServiceProvider Initialize()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IPlateau, Plateau>();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IRoverPosition, RoverPosition>();

            return services.BuildServiceProvider();
        }
    }
}
