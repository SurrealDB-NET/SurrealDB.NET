namespace SurrealDB.QueryBuilder.Linq.Statements;

using System.Linq.Expressions;

public interface ICreateStatement<TRecord>
{
    IReturnStatement<TRecord> Set(Expression<Func<TRecord, TRecord>> setter);

    IReturnStatement<TRecord> Content(TRecord record);
}
