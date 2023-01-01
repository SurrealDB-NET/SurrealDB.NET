using System.Text;
using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Fluent;

internal class GroupByFluent : OrderByFluent, IGroupByFluent
{
    internal GroupByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IOrderByFluent OrderByRandom()
    {
        query.Append(" ORDER RAND()");
        return new OrderByFluent(query);
    }

    public IOrderByFluent OrderBy(string field, SortOrder sortOrder = SortOrder.ASC, TextSortMethod textSortMethod = TextSortMethod.None)
    {
        query.Append(" ORDER ");
        query.Append(field);
        if (textSortMethod is not TextSortMethod.None)
            query.Append($" {textSortMethod.ToString().ToUpper()}");
        query.Append($" {sortOrder.ToString().ToUpper()}");
        return new OrderByFluent(query);
    }
}