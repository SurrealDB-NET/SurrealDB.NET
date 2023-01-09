using System.Linq.Expressions;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.Linq.Shared;

namespace SurrealDB.QueryBuilder.Linq.Create;

public interface ICreateNode<TRecord>
    where TRecord : SurrealRecord
{
    IReturnNode Return(ReturnClause returnClause);

    IReturnNode Return(Expression<Func<TRecord, object>> projections);
}
