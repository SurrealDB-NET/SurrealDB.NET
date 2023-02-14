using System.Linq.Expressions;
using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;
using SurrealDB.QueryBuilder.Linq.Translators;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class FetchNode<TRecord> : TimeoutNode, IFetchStatement<TRecord>
{
	internal FetchNode(StringBuilder query)
		: base(query) { }

	public ITimeoutStatement Fetch(Expression<Func<TRecord, object>>[] fields)
	{
		return new TimeoutNode(Query.Append($" FETCH {string.Join(", ", fields.Select(LambdaExpressionTranslator.Translate))}"));
	}
}
