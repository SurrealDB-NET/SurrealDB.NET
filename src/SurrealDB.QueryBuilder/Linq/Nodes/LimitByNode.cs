using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class LimitByNode<TRecord> : StartAtNode<TRecord>, ILimitByStatement<TRecord>
{
	internal LimitByNode(StringBuilder query)
		: base(query) { }

	public IStartAtStatement<TRecord> LimitBy(uint limit)
		=> new StartAtNode<TRecord>(Query.Append($" LIMIT {limit}"));
}
