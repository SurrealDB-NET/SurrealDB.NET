namespace SurrealDB.QueryBuilder.Fluent.IFluent;

public interface ISelectFluent
{
    IFromFluent From(string source);

    IFromFluent From(string source, string alias);
}