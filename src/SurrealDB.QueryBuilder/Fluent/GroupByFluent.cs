using System.Text;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class GroupByFluent : OrderByFluent, IGroupByFluent
{
    internal GroupByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IOrderByFluent OrderByRandom()
    {
        _query.Append(" ORDER RAND()");
        return new OrderByFluent(_query);
    }

    public IOrderByFluent OrderBy(string field, TextSortMethod textSortMethod = TextSortMethod.None, SortOrder sortOrder = SortOrder.ASC)
    {
        _query.Append(" ORDER ");
        _query.Append(field);
        if (textSortMethod is not TextSortMethod.None)
            _query.Append($" {textSortMethod.ToString().ToUpper()}");
        _query.Append($" {sortOrder.ToString().ToUpper()}");
        return new OrderByFluent(_query);
    }
}