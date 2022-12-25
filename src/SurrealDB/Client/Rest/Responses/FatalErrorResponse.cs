// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace SurrealDB.Client.Rest.Responses;

#pragma warning disable CS8618
public class FatalErrorResponse
{
    public uint Code { get; init; }

    public string Description { get; init; }

    public string Details { get; init; }

    public string Information { get; init; }
}
#pragma warning restore CS8618
