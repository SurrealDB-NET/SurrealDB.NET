namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface ILimitByStatement<TRecord> : IStartAtStatement<TRecord>
{
	IStartAtStatement<TRecord> LimitBy(uint limit);
}
