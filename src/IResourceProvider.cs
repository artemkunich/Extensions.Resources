namespace Akunich.Extensions.Resources;

public interface IResourceProvider
{
    string GetString(string resourceKey);
    string GetString(string resourceKey, params object[] args);
}