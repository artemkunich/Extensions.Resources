using System;
using System.Globalization;
using System.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace Akunich.Extensions.Resources;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddResources(
        this IServiceCollection serviceCollection, 
        Type resourcesType, 
        Func<IServiceProvider,CultureInfo> cultureInfoProvider) =>
        serviceCollection.AddScoped<IResourceProvider>(sp =>
        {
            ResourceProvider.ResourceManager = new ResourceManager(resourcesType);
            return new ResourceProvider(sp, cultureInfoProvider);
        });
}