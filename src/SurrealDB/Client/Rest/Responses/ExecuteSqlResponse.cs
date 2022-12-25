// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace SurrealDB.Client.Rest.Responses;

#pragma warning disable CS8618
public class ExecuteSqlResponse<TResult> where TResult : class
{
    public string Status { get; init; }

    public TResult Result { get; init; }

    public string Time { get; init; }
}
#pragma warning restore CS8618
