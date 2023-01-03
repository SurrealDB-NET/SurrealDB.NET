using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Fluent.Shared;

namespace SurrealDB.QueryBuilder.Fluent.CREATE;

public interface ICreateFluent : IReturnFluent
{
    IReturnFluent Set(params KeyValuePair<string, object?>[] value);

    IReturnFluent Content(SchemalessObject value);
}
