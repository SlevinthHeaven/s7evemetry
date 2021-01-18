using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.iRacing.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddIRacingClient(this IServiceCollection services)
        {
            services.TryAddSingleton<Listeners.IRacingListener>();
            services.TryAddSingleton<Client.IRacingClient>();
            services.TryAddSingleton<Client.IRacingSessionObserver>();
            services.TryAddSingleton<Client.IRacingConnectedObserver>();
            services.TryAddSingleton<Client.IRacingDisconnectedObserver>();
        }
    }
}
