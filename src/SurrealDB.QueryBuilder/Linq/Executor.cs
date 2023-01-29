namespace SurrealDB.QueryBuilder.Linq;

using System.Text;
using Statements;

public class Executor : IExecute
{
    protected readonly StringBuilder Query;

    internal Executor(StringBuilder query)
        => Query = query;

    public string ExecuteAsync<T>()
        => Query.ToString();
}
