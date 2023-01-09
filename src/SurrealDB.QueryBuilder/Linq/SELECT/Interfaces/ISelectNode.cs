using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq;

public interface ISelectNode<TSource>
{
    IWhereNode<TSource> Where(Expression<Predicate<TSource>> predicate);
}
