namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Linq.Expressions;
using System.Text;
using Statements;
using Translators;

internal class GroupByNode<TRecord> : OrderByNode<TRecord>, IGroupByStatement<TRecord>
{
    internal GroupByNode(StringBuilder query)
        : base(query) { }

    public IOrderByStatement<TRecord> GroupBy(params Expression<Func<TRecord, object>>[] fields)
        => new OrderByNode<TRecord>(Query.Append($" GROUP {string.Join(", ", fields.Select(LambdaExpressionTranslator.Translate))}"));
}
