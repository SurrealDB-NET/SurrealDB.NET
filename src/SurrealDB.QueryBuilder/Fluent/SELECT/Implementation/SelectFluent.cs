using System.Text;

namespace SurrealDB.QueryBuilder.Fluent.Select.Implementation;

internal class SelectFluent : ISelectFluent
{
    private readonly StringBuilder _query;

    internal SelectFluent(StringBuilder currentQuery)
        => _query = currentQuery;

    public IFromFluent From(string source)
    {
        _query.Append($" FROM {source}");
        return new FromFluent(_query);
    }

    public IFromFluent From(string tableName, string alias)
    {
        _query.Append($" FROM {tableName} AS {alias}");
        return new FromFluent(_query);
    }
}
