using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface ICreateStatement<TRecord>
{
	IReturnStatement<TRecord> Set(Expression<Func<TRecord, TRecord>> setter);

	IReturnStatement<TRecord> Content(TRecord record);
}
