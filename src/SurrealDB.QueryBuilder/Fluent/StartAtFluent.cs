namespace SurrealDB.QueryBuilder.Fluent;

using System.Text;
using IFluent;

internal class StartAtFluent : FetchFluent, IStartAtFluent
{
    internal StartAtFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IFetchFluent Fetch(params string[] fields)
    {
        Query.Append(" FETCH ");
        Query.Append(string.Join(", ", fields));
        return new FetchFluent(Query);
    }
}
