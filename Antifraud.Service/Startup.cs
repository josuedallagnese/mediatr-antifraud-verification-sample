using Antifraud.Service.Operations.Pix;
using Antifraud.Service.Operations.Ted;
using Antifraud.Service.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Antifraud.Service
{
    public static class Startup
    {
        public static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddMediatR(add => add.RegisterServicesFromAssembly(typeof(Program).Assembly));

            services.AddScoped(
                typeof(IRequestHandler<AntifraudCommand<RequestPixCommand, RequestPixCommandResult>, AntifraudCommandResult<RequestPixCommandResult>>),
                typeof(AntifraudCommandHandler<RequestPixCommand, RequestPixCommandResult>));

            services.AddScoped(
                typeof(IRequestHandler<AntifraudCommand<RequestTedCommand, RequestTedCommandResult>, AntifraudCommandResult<RequestTedCommandResult>>),
                typeof(AntifraudCommandHandler<RequestTedCommand, RequestTedCommandResult>));

            services.AddScoped<IAntifraudClient, InMemoryAntifraudClient>();
            services.AddScoped<IAntifraudRepository, InMemoryAntifraudRepository>();

            return services.BuildServiceProvider().CreateScope().ServiceProvider;
        }
    }
}
