namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Linq.Expressions;
using System.Text;
using Statements;
using Translators;

internal class SelectWhereNode<TRecord> : SplitAtNode<TRecord>, ISelectWhereStatement<TRecord>
{
    internal SelectWhereNode(StringBuilder query)
        : base(query) { }

    public ISplitAtStatement<TRecord> Where(Expression<Func<TRecord, bool>> predicate)
        => new SplitAtNode<TRecord>(Query.Append($" WHERE {LambdaExpressionTranslator.Translate(predicate)}"));
}
