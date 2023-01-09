using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Fluent.Shared;

namespace SurrealDB.QueryBuilder.Fluent.Select;

public interface IFetchFluent : ITimeoutFluent
{
    ITimeoutFluent Timeout(Duration timeout);
}
