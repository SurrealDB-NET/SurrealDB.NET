namespace SurrealDB.Extensions.DependencyInjection;

using Client;
using Client.Rest;
using Client.Rpc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSurrealRestClient(this IServiceCollection services, HttpClient httpClient, Action<SurrealClientOptionsBuilder> optionsBuilder)
    {
        var client = new SurrealRestClient(httpClient, optionsBuilder);

        services.TryAddSingleton<ISurrealClient>(client);

        return services;
    }

    public static IServiceCollection AddSurrealRpcClient(this IServiceCollection services, Action<SurrealClientOptionsBuilder> optionsBuilder)
    {
        var client = new SurrealRpcClient(optionsBuilder);

        services.TryAddSingleton<ISurrealClient>(client);

        return services;
    }
}
