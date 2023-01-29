namespace SurrealDB.QueryBuilder.Fluent;

using System.Text;
using DataModels;
using IFluent;

internal class FetchFluent : TimeoutFluent, IFetchFluent
{
    internal FetchFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ITimeoutFluent Timeout(Duration timeout)
    {
        Query.Append($" TIMEOUT {timeout}");
        return new TimeoutFluent(Query);
    }
}
