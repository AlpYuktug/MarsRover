using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete;
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
            services.AddTransient<IRoverInstruction, RoverInstruction>();
            services.AddTransient<IRoverPosition, RoverPosition>();
            services.AddTransient<IRoverCommand, RoverCommand>();

            services.AddTransient<IRoverInstructionBase, RoverInstructionBackForward>();
            services.AddTransient<IRoverInstructionBase, RoverInstructionLeft>();
            services.AddTransient<IRoverInstructionBase, RoverInstructionRight>();

            return services.BuildServiceProvider();
        }
    }
}
