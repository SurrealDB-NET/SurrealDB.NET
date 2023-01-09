using System.Linq.Expressions;
using System.Text;

namespace SurrealDB.QueryBuilder.Linq;

internal class WhereNode<TSource> : IWhereNode<TSource>
{
    private readonly StringBuilder _query;

    public WhereNode(StringBuilder query, Expression<Predicate<TSource>> predicate)
    {
        _query = query;
        // new WhereNodeTranslator(_query).Visit(predicate);
    }
}
