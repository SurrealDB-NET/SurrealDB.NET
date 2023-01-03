namespace SurrealDB.QueryBuilder.Fluent.Select;

public interface ISplitAtFluent : IGroupByFluent
{
    IGroupByFluent GroupBy(params string[] fields);
}
