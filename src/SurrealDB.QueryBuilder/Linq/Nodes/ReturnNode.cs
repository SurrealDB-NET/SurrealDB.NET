using System.Linq.Expressions;
using System.Text;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.Linq.Statements;
using SurrealDB.QueryBuilder.Linq.Translators;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class ReturnNode<TRecord> : TimeoutNode, IReturnStatement<TRecord>
{
	internal ReturnNode(StringBuilder query)
		: base(query) { }

	public ITimeoutStatement Return(ReturnClause returnClause)
		=> new TimeoutNode(Query.Append($" RETURN {returnClause}"));

	public ITimeoutStatement Return(Expression<Func<TRecord, object>> projection)
		=> new TimeoutNode(Query.Append($" RETURN {LambdaExpressionTranslator.Translate(projection)}"));
}
