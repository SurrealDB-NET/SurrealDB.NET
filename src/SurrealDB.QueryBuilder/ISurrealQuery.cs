using SurrealDB.QueryBuilder.Fluent;

namespace SurrealDB;

public interface ISurrealQuery
{
    ISelectFluent Select();

    ISelectFluent Select(params string[] fields);
}