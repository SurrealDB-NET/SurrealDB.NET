using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

internal class FetchFluent : TimeoutFluent, IFetchFluent
{
    internal FetchFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ITimeoutFluent Timeout(string timeout)
    {
        Query.Append($" TIMEOUT {timeout}");
        return new TimeoutFluent(Query);
    }
}
