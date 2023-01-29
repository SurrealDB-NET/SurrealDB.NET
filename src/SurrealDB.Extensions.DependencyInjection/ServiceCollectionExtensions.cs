namespace SurrealDB.Extensions.DependencyInjection;

using System.Net.WebSockets;
using Client.Rest;
using Client.Rpc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSurrealRestClient(this IServiceCollection services, HttpClient httpClient, Action<SurrealRestClientOptionsBuilder> optionsBuilder)
    {
        var client = new SurrealRestClient(httpClient, optionsBuilder);

        services.TryAddSingleton<ISurrealRestClient>(client);

        return services;
    }

    public static IServiceCollection AddSurrealRpcClient(this IServiceCollection services, ClientWebSocket socket, Action<SurrealRpcClientOptionsBuilder> optionsBuilder)
    {
        var client = new SurrealRpcClient(socket, optionsBuilder);

        services.TryAddSingleton<ISurrealRpcClient>(client);

        return services;
    }
}
