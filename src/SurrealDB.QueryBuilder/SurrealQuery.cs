using System.Text;
using SurrealDB.QueryBuilder.Fluent;

namespace SurrealDB.QueryBuilder;

public class SurrealQuery : ISurrealQuery
{
    private readonly StringBuilder _query;

    public SurrealQuery()
        => _query = new StringBuilder();

    public ISelectFluent Select()
    {
        _query.Append("SELECT *");
        return new SelectFluent(_query);
    }

    public ISelectFluent Select(params string[] fields)
    {
        _query.Append("SELECT ");
        _query.Append(string.Join(", ", fields));
        return new SelectFluent(_query);
    }
}
