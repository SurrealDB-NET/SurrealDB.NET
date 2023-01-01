using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

internal class WhereFluent : SplitAtFluent, IWhereFluent
{
    internal WhereFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ISplitAtFluent SplitAt(params string[] fields)
    {
        query.Append($" SPLIT {string.Join(", ", fields)}");
        return new SplitAtFluent(query);
    }
}
