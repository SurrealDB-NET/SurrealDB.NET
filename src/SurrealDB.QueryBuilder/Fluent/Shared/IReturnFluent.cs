using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Fluent.Shared;

public interface IReturnFluent : ITimeoutFluent
{
    ITimeoutFluent Return(ReturnClause returnResponse);

    ITimeoutFluent Return(params string[] projections);
}
