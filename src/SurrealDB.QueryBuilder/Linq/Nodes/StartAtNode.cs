using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class StartAtNode<TRecord> : FetchNode<TRecord>, IStartAtStatement<TRecord>
{
    internal StartAtNode(StringBuilder query)
        : base(query) { }

    public IFetchStatement<TRecord> StartAt(uint offset)
        => new FetchNode<TRecord>(_query.Append($" START {offset}"));
}
