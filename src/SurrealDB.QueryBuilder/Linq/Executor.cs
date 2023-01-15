using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;

namespace SurrealDB.QueryBuilder.Linq;

public class Executor : IExecute
{
    protected readonly StringBuilder _query;

    internal Executor(StringBuilder query)
        => _query = query;

    public string ExecuteAsync<T>()
        => _query.ToString();
}
