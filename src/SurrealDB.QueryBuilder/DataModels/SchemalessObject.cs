namespace SurrealDB.QueryBuilder.DataModels;

using Translators;

/// <summary>
/// Represents an object containing key value pairs where the value can be of any type. It is equivalent to SurrealDB's Object data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/simple"/>
/// </summary>
public class SchemalessObject : Dictionary<string, object?>
{
    public override string ToString()
    {
        var output = new List<string>();

        foreach (var (key, value) in this)
        {
            var translatedValue = ObjectTranslator.Translate(value);

            output.Add($"\"{key}\":{translatedValue}");
        }

        return $"{{{string.Join(",", output)}}}";
    }
}
