using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;

namespace SurrealDB.QueryBuilder.Linq;

public class Executor : IExecute
{
	protected readonly StringBuilder Query;

	internal Executor(StringBuilder query)
	{
		Query = query;
	}

	public string ExecuteAsync<T>()
	{
		return Query.ToString();
	}
}
