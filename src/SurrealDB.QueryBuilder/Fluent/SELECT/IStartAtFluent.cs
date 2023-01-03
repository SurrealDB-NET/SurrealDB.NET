namespace SurrealDB.QueryBuilder.Fluent.Select;

public interface IStartAtFluent : IFetchFluent
{
    IFetchFluent Fetch(params string[] fields);
}
