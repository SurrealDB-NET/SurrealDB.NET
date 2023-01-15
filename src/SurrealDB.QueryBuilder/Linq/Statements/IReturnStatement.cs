using System.Linq.Expressions;
using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface IReturnStatement<TRecord> : ITimeoutStatement
{
    public ITimeoutStatement Return(ReturnClause returnClause);

    public ITimeoutStatement Return(Expression<Func<TRecord, object>> projection);
}
