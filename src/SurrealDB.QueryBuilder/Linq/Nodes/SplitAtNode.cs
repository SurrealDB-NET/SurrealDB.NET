namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Linq.Expressions;
using System.Text;
using Statements;
using Translators;

internal class SplitAtNode<TRecord> : GroupByNode<TRecord>, ISplitAtStatement<TRecord>
{
    internal SplitAtNode(StringBuilder query)
        : base(query) { }

    public IGroupByStatement<TRecord> SplitAt(params Expression<Func<TRecord, object>>[] fields)
        => new GroupByNode<TRecord>(Query.Append($" SPLIT {string.Join(", ", fields.Select(LambdaExpressionTranslator.Translate))}"));
}
