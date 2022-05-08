using System;
using System.Collections.Generic;
using System.Linq;
using banditoth.MAUI.MVVM.Implementations;
using banditoth.MAUI.MVVM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.Hosting;

namespace banditoth.MAUI.MVVM
{
    public static class MauiAppBuilderExtension
    {
        public static MauiAppBuilder ConfigureMvvm(this MauiAppBuilder builder, Action<IViewModelConnector> configureDelegate)
        {
            IViewModelConnector mvvmBuilder = new ViewModelConnectorService();

            if (configureDelegate != null)
            {
                configureDelegate.Invoke(mvvmBuilder);
            }

            foreach (var connection in mvvmBuilder.GetRegisteredTypes())
            {
                builder.Services.TryAddTransient(connection.Key);

                if (builder.Services.Any(z => z.ServiceType == connection.Value) == false)
                    builder.Services.TryAddTransient(connection.Value);
            }

            builder.Services.TryAdd(new ServiceDescriptor(typeof(IViewModelConnector), mvvmBuilder));
            builder.Services.TryAdd(new ServiceDescriptor(typeof(INavigator), typeof(NavigatorService), ServiceLifetime.Singleton));

            return builder;
        }
    }
}

