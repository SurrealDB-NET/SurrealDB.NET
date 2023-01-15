namespace SurrealDB.QueryBuilder.DataModels;

/// <summary>
/// Represents a none value to specify that a field has no data stored. It is equivalent to SurrealDB's None data type. <br/>
/// <see href="https://surrealdb.com/features#datamodel"/>
/// </summary>
public readonly struct None<T>
{
    public static implicit operator T?(None<T> _)
        => default;

    public override string ToString()
        => "none";
}
