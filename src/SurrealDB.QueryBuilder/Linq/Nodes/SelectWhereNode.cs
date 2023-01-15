using System.Linq.Expressions;
using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;
using SurrealDB.QueryBuilder.Linq.Translators;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class SelectWhereNode<TRecord> : SplitAtNode<TRecord>, ISelectWhereStatement<TRecord>
{
    internal SelectWhereNode(StringBuilder query)
        : base(query) { }

    public ISplitAtStatement<TRecord> Where(Expression<Func<TRecord, bool>> predicate)
        => new SplitAtNode<TRecord>(_query.Append($" WHERE {LambdaExpressionTranslator.Translate(predicate)}"));
}
