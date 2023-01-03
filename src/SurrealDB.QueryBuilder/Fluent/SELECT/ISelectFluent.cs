namespace SurrealDB.QueryBuilder.Fluent.Select;

public interface ISelectFluent
{
    IFromFluent From(string source);

    IFromFluent From(string source, string alias);
}
