namespace SurrealDB.QueryBuilder.Fluent.Select;

public interface IWhereFluent : ISplitAtFluent
{
    ISplitAtFluent SplitAt(params string[] fields);
}
