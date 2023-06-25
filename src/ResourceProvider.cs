using System;
using System.Globalization;
using System.Resources;

namespace Akunich.Extensions.Resources;

internal sealed class ResourceProvider : IResourceProvider
{
    internal static ResourceManager ResourceManager;

    private readonly CultureInfo _cultureInfo;

    public ResourceProvider(IServiceProvider serviceProvider, Func<IServiceProvider, CultureInfo> cultureInfoProvider)
    {
        _cultureInfo = cultureInfoProvider(serviceProvider);
    }

    public string GetString(string resourceKey) => 
        ResourceManager.GetString(resourceKey, _cultureInfo) ?? resourceKey;

    public string GetString(string resourceKey, params object[] args)
    {
        var resource = ResourceManager.GetString(resourceKey, _cultureInfo);
        if (resource is null)
            return resourceKey;
        
        return string.Format(resource, args);
    } 
}