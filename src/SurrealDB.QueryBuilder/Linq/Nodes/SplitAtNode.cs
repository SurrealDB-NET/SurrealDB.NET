using System.Linq.Expressions;
using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;
using SurrealDB.QueryBuilder.Linq.Translators;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class SplitAtNode<TRecord> : GroupByNode<TRecord>, ISplitAtStatement<TRecord>
{
	internal SplitAtNode(StringBuilder query)
		: base(query) { }

	public IGroupByStatement<TRecord> SplitAt(params Expression<Func<TRecord, object>>[] fields)
	{
		return new GroupByNode<TRecord>(Query.Append($" SPLIT {string.Join(", ", fields.Select(LambdaExpressionTranslator.Translate))}"));
	}
}
