using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Fluent.Shared;

public interface IReturnFluent : ITimeoutFluent
{
    ITimeoutFluent Return(ReturnResponse returnResponse);

    ITimeoutFluent Return(params string[] projections);
}
