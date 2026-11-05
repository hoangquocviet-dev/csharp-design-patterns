using System.Text;

namespace DesignPatterns.Creational.Builder;

public class SqlFluentQueryBuilder {
    private string _table = "";
    private string _columns = "*";
    private string _where = "";

    public SqlFluentQueryBuilder From(string table) { _table = table; return this; }
    public SqlFluentQueryBuilder Select(string columns) { _columns = columns; return this; }
    public SqlFluentQueryBuilder Where(string condition) { _where = condition; return this; }

    public string Build() {
        var sb = new StringBuilder($"SELECT {_columns} FROM {_table}");
        if (!string.IsNullOrEmpty(_where)) sb.Append($" WHERE {_where}");
        return sb.ToString();
    }
}
