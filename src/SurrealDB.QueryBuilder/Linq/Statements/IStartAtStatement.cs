namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface IStartAtStatement<TRecord> : IFetchStatement<TRecord>
{
	IFetchStatement<TRecord> StartAt(uint offset);
}
