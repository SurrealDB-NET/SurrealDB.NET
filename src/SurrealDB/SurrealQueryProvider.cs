// using System.Linq.Expressions;

// namespace SurrealDB;

// public class SurrealQueryProvider : IQueryProvider
// {
//     public IQueryable CreateQuery(Expression expression)
//         => new SurrealTable<TRecord>(this, expression);

//     public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
//     {
//         throw new NotImplementedException();
//     }

//     public object? Execute(Expression expression)
//     {
//         throw new NotImplementedException();
//     }

//     public TResult Execute<TResult>(Expression expression)
//     {
//         throw new NotImplementedException();
//     }
// }
