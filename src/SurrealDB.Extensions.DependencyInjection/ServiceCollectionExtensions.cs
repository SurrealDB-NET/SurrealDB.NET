using System.Net.WebSockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SurrealDB.Client.Rest;
using SurrealDB.Client.Rpc;

namespace SurrealDB.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSurrealRestClient(
		this IServiceCollection services, HttpClient httpClient, Action<SurrealRestClientOptionsBuilder> optionsBuilder
	)
	{
		var client = new SurrealRestClient(httpClient, optionsBuilder);

		services.TryAddSingleton<ISurrealRestClient>(client);

		return services;
	}

	public static IServiceCollection AddSurrealRpcClient(
		this IServiceCollection services, ClientWebSocket socket, Action<SurrealRpcClientOptionsBuilder> optionsBuilder
	)
	{
		var client = new SurrealRpcClient(socket, optionsBuilder);

		services.TryAddSingleton<ISurrealRpcClient>(client);

		return services;
	}
}
