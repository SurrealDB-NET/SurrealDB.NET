using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class StartAtNode<TRecord> : FetchNode<TRecord>, IStartAtStatement<TRecord>
{
	internal StartAtNode(StringBuilder query)
		: base(query) { }

	public IFetchStatement<TRecord> StartAt(uint offset)
	{
		return new FetchNode<TRecord>(Query.Append($" START {offset}"));
	}
}
