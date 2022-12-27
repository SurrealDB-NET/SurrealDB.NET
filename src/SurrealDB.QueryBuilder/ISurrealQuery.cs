using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB;

public interface ISurrealQuery
{
    ISelectFluent Select();

    ISelectFluent Select(params string[] fields);
}