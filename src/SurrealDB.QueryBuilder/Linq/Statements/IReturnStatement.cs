namespace SurrealDB.QueryBuilder.Linq.Statements;

using System.Linq.Expressions;
using Enums;

public interface IReturnStatement<TRecord> : ITimeoutStatement
{
    public ITimeoutStatement Return(ReturnClause returnClause);

    public ITimeoutStatement Return(Expression<Func<TRecord, object>> projection);
}
