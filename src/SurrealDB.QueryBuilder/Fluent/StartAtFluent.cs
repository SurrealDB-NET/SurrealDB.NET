using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

internal class StartAtFluent : FetchFluent, IStartAtFluent
{
    internal StartAtFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IFetchFluent Fetch(params string[] fields)
    {
        query.Append(" FETCH ");
        query.Append(string.Join(", ", fields));
        return new FetchFluent(query);
    }
}