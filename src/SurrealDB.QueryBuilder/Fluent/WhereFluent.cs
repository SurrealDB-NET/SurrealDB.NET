using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class WhereFluent : SplitAtFluent, IWhereFluent
{
    internal WhereFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ISplitAtFluent SplitAt(params string[] fields)
    {
        _query.Append($" SPLIT {string.Join(", ", fields)}");
        return new SplitAtFluent(_query);
    }
}