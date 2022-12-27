using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class SplitAtFluent : GroupByFluent, ISplitAtFluent
{
    internal SplitAtFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IGroupByFluent GroupBy(params string[] fields)
    {
        _query.Append($" GROUP {string.Join(", ", fields)}");
        return new GroupByFluent(_query);
    }
}