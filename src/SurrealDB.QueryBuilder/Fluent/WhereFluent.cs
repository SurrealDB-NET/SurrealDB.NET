namespace SurrealDB.QueryBuilder.Fluent;

using System.Text;
using IFluent;

internal class WhereFluent : SplitAtFluent, IWhereFluent
{
    internal WhereFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ISplitAtFluent SplitAt(params string[] fields)
    {
        Query.Append($" SPLIT {string.Join(", ", fields)}");
        return new SplitAtFluent(Query);
    }
}
