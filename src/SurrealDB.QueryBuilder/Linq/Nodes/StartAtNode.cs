namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Text;
using Statements;

internal class StartAtNode<TRecord> : FetchNode<TRecord>, IStartAtStatement<TRecord>
{
    internal StartAtNode(StringBuilder query)
        : base(query) { }

    public IFetchStatement<TRecord> StartAt(uint offset)
        => new FetchNode<TRecord>(Query.Append($" START {offset}"));
}
