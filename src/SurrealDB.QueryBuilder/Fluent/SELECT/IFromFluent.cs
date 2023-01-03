namespace SurrealDB.QueryBuilder.Fluent.Select;

public interface IFromFluent : IWhereFluent
{
    IWhereFluent Where(string predicate);
}
