using System.Linq.Expressions;
using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;
using SurrealDB.QueryBuilder.Linq.Translators;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class GroupByNode<TRecord> : OrderByNode<TRecord>, IGroupByStatement<TRecord>
{
    internal GroupByNode(StringBuilder query)
        : base(query) { }

    public IOrderByStatement<TRecord> GroupBy(params Expression<Func<TRecord, object>>[] fields)
        => new OrderByNode<TRecord>(_query.Append($" GROUP {string.Join(", ", fields.Select(f => LambdaExpressionTranslator.Translate(f)))}"));
}
