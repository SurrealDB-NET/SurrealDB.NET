using SurrealDB.QueryBuilder.Fluent.Shared;

namespace SurrealDB.QueryBuilder.Fluent.Update;

public interface IWhereFluent : IReturnFluent
{
    IReturnFluent Where(string condition);
}
