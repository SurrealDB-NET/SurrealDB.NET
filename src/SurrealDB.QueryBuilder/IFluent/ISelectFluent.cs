namespace SurrealDB.QueryBuilder.Fluent;

public interface ISelectFluent
{
    IFromFluent From(string source);

    IFromFluent From(string source, string alias);
}