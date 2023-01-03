using SurrealDB.QueryBuilder.DataModels;

namespace SurrealDB.QueryBuilder.Fluent.Update;

public interface IUpdateFluent
{
    IWhereFluent Set(params KeyValuePair<string, object?>[] value);

    IWhereFluent Content(SchemalessObject value);

    IWhereFluent Merge(SchemalessObject value);

    IWhereFluent Patch(SchemalessObject value);
}
