using System.Linq.Expressions;
using System.Text;

namespace SurrealDB.QueryBuilder.Linq;

internal class SelectNode<TSource> : ISelectNode<TSource>
{
    private readonly StringBuilder _query;

    public SelectNode(StringBuilder query, Expression<Func<TSource, object?>> selector, object recordId = default!)
    {
        _query = query;
        new SelectNodeTranslator<TSource>(_query, selector, recordId);
    }
    public IWhereNode<TSource> Where(Expression<Predicate<TSource>> predicate)
        => new WhereNode<TSource>(_query, predicate);
}
