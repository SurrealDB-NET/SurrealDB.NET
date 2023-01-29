namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Text;
using Statements;

internal class LimitByNode<TRecord> : StartAtNode<TRecord>, ILimitByStatement<TRecord>
{
    internal LimitByNode(StringBuilder query)
        : base(query) { }

    public IStartAtStatement<TRecord> LimitBy(uint limit)
        => new StartAtNode<TRecord>(Query.Append($" LIMIT {limit}"));
}
